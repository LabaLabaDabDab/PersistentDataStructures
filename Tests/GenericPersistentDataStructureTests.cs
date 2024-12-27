using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using PersistentDataStructures.Collections;
using PersistentDataStructures.Implementation.Collections;
using PersistentDataStructures.Implementation.UndoRedo;

namespace PersistentDataStructures.Tests
{
    [TestFixture]
    public class GenericPersistentDataStructureTests
    {
        [Test(Description = "Test PersistentLinkedList implementation")]
        public void ImplementationPersistentLinkedListTest()
        {
            var structure = new PersistentLinkedList<int>();

            PersistentDataStructureTest<IPersistentLinkedList<int>>(structure);
            PersistentDataStructureWithStackTest(structure);
        }
        
        [Test(Description = "Test PersistentList implementation")]
        public void ImplementationPersistentListTest()
        {
            var structure = new PersistentList<int>();

            PersistentDataStructureTest(structure);
        }
        
        [Test(Description = "Test UndoRedoLinkedList implementation")]
        public void ImplementationUndoRedoLinkedListTest()
        {
            var structure = new UndoRedoLinkedList<int>();

            PersistentDataStructureTest<IPersistentLinkedList<int>>(structure);
            PersistentDataStructureWithStackTest(structure);
        }
        
        [Test(Description = "Test UndoRedoList implementation")]
        public void ImplementationUndoRedoListTest()
        {
            var structure = new UndoRedoList<int>();

            PersistentDataStructureTest<IPersistentList<int>>(structure);
        }
        
        [Test(Description = "Test UndoRedoStack implementation")]
        public void ImplementationUndoRedoStackTest()
        {
            var structure = new UndoRedoStack<int>();

            PersistentDataStructureTest<IPersistentStack<int>>(structure);
            PersistentDataStructureWithStackTest(structure);
        }

        private static void PersistentDataStructureTest<T>(IPersistentDataStructure<int, T> a) where T: IPersistentDataStructure<int, T>
        {
            a.IsEmpty.Should().BeTrue();

            var b = a.Add(0);
            b.Count.Should().Be(1);
            b.IsEmpty.Should().BeFalse();

            var c = a.AddRange(Enumerable.Range(0, 5));
            c.Count.Should().Be(5);
            
            var d = a.AddRange(Enumerable.Range(0, 5).ToArray());
            d.Count.Should().Be(5);
        }
        
        private static void PersistentDataStructureWithStackTest(IPersistentDataStructure<int, IPersistentStack<int>> a)
        {
            a.IsEmpty.Should().BeTrue();

            var b = a.Add(0);
            b.Count.Should().Be(1);
            b.IsEmpty.Should().BeFalse();

            var c = a.AddRange(Enumerable.Range(0, 5));
            c.Count.Should().Be(5);
            
            var d = a.AddRange(Enumerable.Range(0, 5).ToArray());
            d.Count.Should().Be(5);

            var e = d.Clear();
            e.Count.Should().Be(0);
        }
    }
}