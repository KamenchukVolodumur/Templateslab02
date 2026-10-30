namespace Task1;
using System.Numerics;
public interface IAdder<in T> {
    public bool Add(T val);
}

public interface ITaker<out T> {
    public T? Take();
}

public class Box<T> {
    public T Value { get; set; }
    public Box(T val) { Value = val; }
    public override string ToString() { return $"Box: {Value}"; }
}

// =============================================================
// TODO 1 
// =============================================================

public class NumBox<T> : Box<T> where T: INumber<T>  {
    public NumBox(T val):base(val){
        return;
    }
    public static NumBox<T> operator +(NumBox<T> a, NumBox<T> b){
        return new NumBox<T>(a.Value + b.Value);
    }
}
// =============================================================
// TODO 2 
// =============================================================

public class StringBox: Box<string> {
    public StringBox(string a): base(a){}
    public static StringBox operator +(StringBox a, StringBox b){
        return new StringBox(a.Value + ";" + b.Value);
    }
}
// =============================================================
// TODO 3 
// =============================================================

public class Shelf<T>:  IAdder<T>, ITaker<T>  /* add missing interfaces and constrains here */ {
    public bool Add(T val){
        if(_current == Space){
            return false;
        }else{
            _items[_current] = val;
            _current++;
            return true;
        }
    }
    public T? Take(){
        if(_current == 0){
            return default(T);
        }else{
            T result = _items[_current-1];
            _current--;
            return result;
        }
    }
    public int Space { get; init; } = 5;
    private int _current = 0;
    private T?[] _items;

    public Shelf(int space) {
        _items = new T?[space];
        Space = space;
    }
}