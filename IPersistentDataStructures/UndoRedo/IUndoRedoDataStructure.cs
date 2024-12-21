using PersistentDataStructures.Collections;

namespace PersistentDataStructures.UndoRedo
{
    public interface IUndoRedoDataStructure<T, TSelf> : IUndoRedo<IUndoRedoDataStructure<T, TSelf>>, 
        IPersistentDataStructure<T, IUndoRedoDataStructure<T, TSelf>> where TSelf : IUndoRedoDataStructure<T, TSelf>
    {
    }
}