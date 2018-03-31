using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Clinic : IClinic, IEnumerable<Pet>
{
    private Pet[] pets;
    private int midIndex;
    public string Name { get; private set; }

    private int rooms;

    public int Rooms
    {
        get { return this.rooms; }
        private set
        {
            ValidateRooms(value);
            this.rooms = value;
        }
    }

    public Clinic(string name, int rooms)
    {
        this.Name = name;
        this.Rooms = rooms;
        this.pets = new Pet[this.Rooms];
        this.midIndex = this.Rooms / 2;
    }

    public bool AddPet(Pet pet)
    {
        if(!this.HasEmptyRooms())
            return false;

        if(this.pets[midIndex] == null)
        {
            this.pets[midIndex] = pet;
            return true;
        }

        for (int i = 1; i <= this.midIndex; i++)
        {
            if(this.pets[this.midIndex - i] == null)
            {
                this.pets[this.midIndex - i] = pet;
                break;
            }
            if (this.pets[this.midIndex + i] == null)
            {
                this.pets[this.midIndex + i] = pet;
                break;
            }
        }

        return true;
    }

    public bool ReleasePet()
    {
        if(!this.pets.Any(p => p != null))
            return false;

        bool shouldBreak = false;

        for (int i = midIndex; i < this.pets.Length; i++)
        {
            if(this.pets[i] != null)
            {
                this.pets[i] = null;
                shouldBreak = true;
                break;
            }
        }
        if(!shouldBreak)
        {
            for (int i = 0; i < midIndex; i++)
            {
                if(this.pets[i] != null)
                {
                    this.pets[i] = null;
                    break;
                }
            }
        }

        return true;
    }

    public bool HasEmptyRooms()
    {
        if(this.pets.Any(p => p == null))
        {
            return true;
        }
        return false;
    }

    public void Print(int room)
    {
        Console.WriteLine(this.pets[room - 1]?.ToString() ?? "Room empty");
    }

    public void PrintAll()
    {
        foreach (var pet in this.pets)
        {
            Console.WriteLine(pet?.ToString() ?? "Room empty");
        }
    }

    private void ValidateRooms(int numOfRooms)
    {
        if (numOfRooms % 2 == 0)
            throw new InvalidOperationException("Invalid Operation!");
    }

    public IEnumerator<Pet> GetEnumerator()
    {
        for (int i = 0; i < this.Rooms; i++)
        {
            yield return this.pets[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
