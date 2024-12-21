﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace PersistentDataStructures.Collections
{
    public interface IPersistentList<T> : IPersistentDataStructure<T, IPersistentList<T>>, IImmutableList<T>
    {
        new IPersistentList<T> Add(T item);
        new IPersistentList<T> AddRange(IEnumerable<T> items);
        new IPersistentList<T> AddRange(IReadOnlyCollection<T> items);
        new IPersistentList<T> Insert(int index, T item);
        new IPersistentList<T> InsertRange(int index, IEnumerable<T> items);
        new IPersistentList<T> Remove(T value, IEqualityComparer<T>? equalityComparer);
        new IPersistentList<T> RemoveAll(Predicate<T> match);
        new IPersistentList<T> RemoveAt(int index);
        new IPersistentList<T> RemoveRange(IEnumerable<T> items, IEqualityComparer<T>? equalityComparer);
        new IPersistentList<T> RemoveRange(int index, int count);
        new IPersistentList<T> Replace(T oldValue, T newValue, IEqualityComparer<T>? equalityComparer);
        new IPersistentList<T> SetItem(int index, T value);
        new IPersistentList<T> Clear();
    }
}