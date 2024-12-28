using System.Diagnostics;
using PersistentDataStructures.Implementation.Collections;
using PersistentDataStructures.Implementation.UndoRedo;

public class Program
{
    private static void Main(string[] args)
    {
        var listA = new UndoRedoList<int>();
        var listB = listA.Add(1);
        var listC = listB.Undo();
    }
}