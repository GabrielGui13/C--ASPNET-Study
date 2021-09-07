using System;
using System.Collections.Generic;

public class HttpCookie {
    private readonly Dictionary<string, string> _dictionary; //<key, value>

    public HttpCookie() {
        _dictionary = new Dictionary<string, string>();
    }

    public string this[string key] { //public string "value" this [string "key"], o this acessa a classe e depois a chave => class[key]
        get { return _dictionary[key]; }
        set { _dictionary[key] = value; }
    }
}