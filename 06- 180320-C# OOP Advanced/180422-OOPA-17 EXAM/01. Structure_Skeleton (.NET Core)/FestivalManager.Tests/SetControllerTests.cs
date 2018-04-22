// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    //using FestivalManager.Core.Controllers;
    //using FestivalManager.Core.Controllers.Contracts;
    //using FestivalManager.Entities;
    //using FestivalManager.Entities.Contracts;
    //using FestivalManager.Entities.Instruments;
    //using FestivalManager.Entities.Sets;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class SetControllerTests
    {
        private IStage stage;
        private ISetController setController;

        [SetUp]
        public void SetUpSetController()
        {
            this.stage = new Stage();
            this.setController = new SetController(stage);
        }


        [Test]
        public void DidNotPerformTest()
        {
            ISet set = new Short("Set1");

            this.stage.AddSet(set);

            string result = this.setController.PerformSets();

            Assert.IsTrue(result.EndsWith("-- Did not perform"));
        }

        [Test]
        public void AppendSetCountTest()
        {
            ISet set = new Short("Set1");

            this.stage.AddSet(set);

            string result = this.setController.PerformSets();

            Assert.IsTrue(result.StartsWith("1. Set1"));
        }

        [Test]
        public void SuccessfulSetTest()
        {
            ISet set = new Short("Set1");

            this.stage.AddSet(set);
            ISong song = new Song("Song1", new System.TimeSpan(0, 5, 0));

            this.stage.AddSong(song);

            set.AddSong(song);

            IPerformer performer = new Performer("Gosho", 20);
            performer.AddInstrument(new Guitar());
            this.stage.AddPerformer(performer);

            set.AddPerformer(performer);

            string result = this.setController.PerformSets();

            Assert.IsTrue(result.EndsWith("-- Set Successful"));
        }

        [Test]
        public void InstrumentsWearTest()
        {
            ISet set = new Short("Set1");

            this.stage.AddSet(set);
            ISong song = new Song("Song1", new System.TimeSpan(0, 5, 0));

            this.stage.AddSong(song);

            set.AddSong(song);

            IPerformer performer = new Performer("Gosho", 20);
            performer.AddInstrument(new Guitar());
            this.stage.AddPerformer(performer);

            set.AddPerformer(performer);

            this.setController.PerformSets();

            FieldInfo instrumentsInfo = typeof(Performer).GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(f => f.FieldType == typeof(List<IInstrument>));

            List<IInstrument> instruments = ((List<IInstrument>)instrumentsInfo.GetValue(performer)).Take(1).ToList();
            IInstrument instrument = instruments[0];

            Assert.That(instrument.Wear, Is.EqualTo(40));
        }

        [Test]
        public void InstrumentsWearToZeroTest()
        {
            ISet set = new Short("Set1");

            this.stage.AddSet(set);
            ISong song = new Song("Song1", new System.TimeSpan(0, 5, 0));

            this.stage.AddSong(song);

            set.AddSong(song);

            IPerformer performer = new Performer("Gosho", 20);
            performer.AddInstrument(new Guitar());
            this.stage.AddPerformer(performer);

            set.AddPerformer(performer);

            string result = this.setController.PerformSets();
            result = this.setController.PerformSets();
            result = this.setController.PerformSets();

            FieldInfo instrumentsInfo = typeof(Performer).GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(f => f.FieldType == typeof(List<IInstrument>));

            List<IInstrument> instruments = ((List<IInstrument>)instrumentsInfo.GetValue(performer)).Take(1).ToList();
            IInstrument instrument = instruments[0];

            Assert.That(instrument.Wear, Is.EqualTo(0));
        }
    }
}