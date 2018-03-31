using System;
using System.Collections.Generic;
using System.Text;

public interface IClinic
{
    string Name { get; }
    int Rooms { get; }
    bool AddPet(Pet pet);
    bool ReleasePet();
    bool HasEmptyRooms();
    void Print(int room);
    void PrintAll();
}
