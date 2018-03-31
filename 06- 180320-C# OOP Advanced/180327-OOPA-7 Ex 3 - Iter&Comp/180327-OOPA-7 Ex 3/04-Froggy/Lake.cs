using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Lake : IEnumerable<int>
{
    private readonly List<int> Stones;

    public Lake(int[] stones)
    {
        this.Stones = new List<int>(stones);
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < this.Stones.Count; i += 2)
        {
            yield return this.Stones[i];
        }

        int lastIndex = this.Stones.Count % 2 == 0 ? this.Stones.Count - 1 : this.Stones.Count - 2;

        for (int i = lastIndex; i >= 0; i -= 2)
        {
            yield return this.Stones[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
