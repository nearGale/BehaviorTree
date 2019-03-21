using System;
using System.Collections.Generic;

public class ObjManager{
    static int idx = 0;
    public static Dictionary<int, object> dict = new Dictionary<int, object>();

    public static int RegObj(object obj){
        dict.Add(idx, obj);
        idx++;
        return idx-1;
    }

    public static object GetObj(int id){
        if(dict.ContainsKey(id))
            return dict[id];
        else
            return null;
    }
}