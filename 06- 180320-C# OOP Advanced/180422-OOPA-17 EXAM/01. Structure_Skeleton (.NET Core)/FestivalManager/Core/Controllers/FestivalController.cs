namespace FestivalManager.Core.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Entities.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;
    using Constants;
    using System.Collections.Generic;

    public class FestivalController : IFestivalController
    {
        private const string TimeFormat = "mm\\:ss";
        //private const string TimeFormatLong = "{0:2D}:{1:2D}";
        //private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

        private readonly IStage stage;
        private ISetFactory setFactory;
        private IInstrumentFactory instrumentFactory;
        private IPerformerFactory performerFactory;
        private ISongFactory songFactory;

        public FestivalController(IStage stage)
        {
            this.stage = stage;
            this.setFactory = new SetFactory();
            this.instrumentFactory = new InstrumentFactory();
            this.performerFactory = new PerformerFactory();
            this.songFactory = new SongFactory();
        }

        public string ProduceReport()
        {
            StringBuilder sb = new StringBuilder();

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            sb.AppendLine(string.Format(Constants.TotalFestivalTime,FormatTime(totalFestivalLength)));

            foreach (var set in this.stage.Sets)
            {
                sb.AppendLine($"--{set.Name} ({FormatTime(set.ActualDuration)}):");

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    sb.AppendLine($"---{performer.Name} ({instruments})");
                }

                if (!set.Songs.Any())
                    sb.AppendLine("--No songs played");
                else
                {
                    sb.AppendLine("--Songs played:");
                    foreach (var song in set.Songs)
                    {
                        sb.AppendLine($"----{song.Name} ({song.Duration.ToString(TimeFormat)})");
                    }
                }
            }

            return sb.ToString().Trim();
        }

        private string FormatTime(TimeSpan timeSpan)
        {
            double minutes = timeSpan.TotalMinutes;
            double seconds = timeSpan.TotalSeconds % 60;

            return $"{minutes:00}:{seconds:00}";
        }

        public string RegisterSet(string[] args)
        {
            string name = args[0];
            string type = args[1];

            ISet set = this.setFactory.CreateSet(name, type);

            this.stage.AddSet(set);

            return string.Format(Constants.SuccessfulAddedSet, set.GetType().Name);
        }

        public string SignUpPerformer(string[] args)
        {
            string name = args[0];
            int age = int.Parse(args[1]);

            IPerformer performer = this.performerFactory.CreatePerformer(name, age);

            if (args.Length > 2)
            {
                string[] instrumentNames = args.Skip(2).ToArray();

                List<IInstrument> instruments = instrumentNames
                    .Select(i => this.instrumentFactory.CreateInstrument(i))
                    .ToList();

                foreach (var instrument in instruments)
                {
                    performer.AddInstrument(instrument);
                }
            }

            this.stage.AddPerformer(performer);

            return string.Format(Constants.SuccessfulSignedPerformer, performer);
        }

        public string RegisterSong(string[] args)
        {
            string name = args[0];
            TimeSpan.TryParseExact(args[1], TimeFormat, CultureInfo.InvariantCulture, out TimeSpan duration);

            ISong song = this.songFactory.CreateSong(name, duration);

            this.stage.AddSong(song);

            return string.Format(Constants.SuccessfullRegisteredSong, song);
        }

        public string AddSongToSet(string[] args)
        {
            var songName = args[0];
            var setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException(Constants.SetNotFound);
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException(Constants.SongNotFound);
            }

            ISet set = this.stage.GetSet(setName);
            ISong song = this.stage.GetSong(songName);

            set.AddSong(song);

            return string.Format(Constants.SuccessfullAddedSongToSet, song, set.Name);
        }

        public string AddPerformerToSet(string[] args)
        {
            var performerName = args[0];
            var setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException(Constants.PerformerNotFound);
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException(Constants.SetNotFound);
            }

            IPerformer performer = this.stage.GetPerformer(performerName);
            var set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return string.Format(Constants.SuccessfulAddedPerformerToSet, performer, set.Name);
        }

        public string RepairInstruments(string[] args)
        {
            var instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return string.Format(Constants.RepairedInstruments, instrumentsToRepair.Length);
        }
    }
}