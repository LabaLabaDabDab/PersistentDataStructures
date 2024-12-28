using System.Diagnostics;
using PersistentDataStructures.Implementation.Collections;
using PersistentDataStructures.Implementation.UndoRedo;

namespace Test;

public class Program
{
    private static void Main(string[] args)
    {
        // PersistentList example
        var listA = new PersistentList<int>();
        var listB = listA.Add(15);
        var e = listB[0];
        Debug.Assert(e == 15);  // listB should contain 15

        var listC = listB.Set(0, 33);
        Debug.Assert(listB[0] == 15);  // listB is unchanged
        Debug.Assert(listC[0] == 33);  // listC is updated with 33

        // PersistentDictionary example
        var dictA = new PersistentDictionary<int, string>();
        var dictB = dictA.Set(15, "B");
        var dictC = dictA.Set(15, "C");
        Debug.Assert(dictB[15] != dictC[15]);  // dictB and dictC should differ for key 15
        var dictD = dictC.SetItems(new[] { new KeyValuePair<int, string>(15, "D"), new KeyValuePair<int, string>(87, "A") });
        Debug.Assert(dictD.Count == 2);  // dictD should have two entries

        // PersistentLinkedList example
        var llA = new PersistentLinkedList<int>();
        var llB = llA.AddLast(15);
        var llC = llB.AddFirst(71);
        Debug.Assert(llB.First != llC.FirstOrDefault());  // llB and llC should have different first elements
        var llD = llC.Insert(1, 1000);
        Debug.Assert(llD.First == llC.First && llD.Last == llC.Last);  // llD should have same first and last elements as llC

        // PersistentStack example
        var stackA = new PersistentStack<char>();
        var stackB = stackA.Push('a');
        Debug.Assert(stackA.IsEmpty);  // stackA should be empty
        var stackC = stackB.Push('d');
        Debug.Assert(stackC.Peek() == 'd' && stackB.Peek() == 'a');  // stackB should have 'a', stackC should have 'd'
    }
}
