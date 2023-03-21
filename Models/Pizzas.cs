using System.Net.Mime;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Data;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using Pizzas.API.Models;

namespace Pizzas.API;

public class Pizzas{

    private int _IdPizza;

    private string _Nombre;

    private bool _LibreGluten;


    private float _Importe;

    private string _Descripcion;


public Pizzas(){

}

public Pizzas(int IdPizza, string Nombre, bool LibreGluten, float Importe, string Descripcion){

    _IdPizza = IdPizza;
    _Nombre = Nombre;
    _LibreGluten = LibreGluten;
    _Importe = Importe;
    _Descripcion = Descripcion;
}

public int IdPizza
{
    set{_IdPizza = value;}
    get{return _IdPizza;}
}

public string Nombre
{
    set{_Nombre = value;}
    get{return _Nombre;}
}

public bool LibreGluten
{
    set{_LibreGluten = value;}
    get{return _LibreGluten;}
}

public float Importe
{
    set{_Importe = value;}
    get{return _Importe;}
}

public string Descripcion
{
    set{_Descripcion = value;}
    get{return _Descripcion;}
}
}