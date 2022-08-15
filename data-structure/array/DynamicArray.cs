using System;

public class DynamicArray {
  private int[] array;
  public int Count;
  public int Capacity;
  private int InitialCapacity;

  public DynamicArray(){
    Capacity = 8;
    Count = 0;
    InitialCapacity = Capacity;
    array = new int[Capacity]; 
  }

  public void Add(int data) {
    if(Count == Capacity) {
      Capacity *= 2;
      ResizeArray(Capacity);
    }

    array[Count] = data;
    Count++;
  }

  public void Insert(int index, int data) {
    if(index < 0 || index > Count) throw new Exception("Invalid index");
    if(index == Count) {
      Add(data);
      return;
    }
    if(Count == Capacity) {
      Capacity *= 2;
      ResizeArray(Capacity);
    }

    for(int i = Count; i > index; i--) {
      array[i] = array[i-1];
    }
    array[index] = data;
    Count++;
  }

  public void Remove(int data) {
    int dataIndex = IndexOf(data);
    if(dataIndex < 0) return;
    RemoveAt(dataIndex);
  }
  
  public void RemoveAt(int index) {
    if(index < 0 || index >= Count) throw new Exception("Invalid index");

    for(int i = index; i < Count - 1; i++) {
      array[i] = array[i+1];
    }
    Count--;
  }
  
  public void Print() {
    if(Count == 0) throw new Exception("Array is empty");
    for(int i = 0; i < Count; i++) {
       Console.WriteLine($"[{i}] --> {array[i]}");
    }
  }

  public void Clear() {
    Count = 0;
    Capacity = InitialCapacity;
    Array.Clear(array, 0, array.Length);

    array = new int[Capacity];
  }
  
  public int IndexOf(int data) {
    for(int i = 0; i < Count; i++) {
      if(array[i] == data) return i;
    }
    return -1;
  }

  public bool Contains(int data) {
    for(int i = 0; i < Count; i++) {
      if(array[i] == data) return true;
    }
    return false;
  }
  
  public void Sort() {
    // Insertion Sort
    for(int i = 0; i < Count; i++) {
        int aux = array[i];
        int index = i;
        while(index > 0 && aux < array[index-1]) {
            array[index] = array[index-1];
            index--;
        }
        array[index] = aux;
    }
  }
  
  private void ResizeArray(int newCapacity) {
    int[] newArray = new int[newCapacity];

    for(int i = 0; i < array.Length; i++) {
      newArray[i] = array[i];
    }
    array = newArray;
  }
}
          
class Program {
  public static void Main (string[] args) {
    DynamicArray array = new DynamicArray();
    try {
        array.Add(8);
        array.Insert(0, 15);
        array.Clear();

        array.Add(7);
        array.Add(5);
        array.Add(1);
        array.Insert(1, 9);
        array.Remove(9);
        array.Sort();
        array.Print();
        
        Console.WriteLine(array.Contains(120));
        Console.WriteLine(array.IndexOf(5));
    } catch (Exception e) {
        Console.WriteLine(e.Message);
    }
  }
}