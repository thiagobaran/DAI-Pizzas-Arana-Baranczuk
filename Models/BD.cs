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

namespace Pizzas.API.Models;

public static class BD{

    private static string CONNECTION_STRING = @"Server=A-PHZ2-CEO-021;DataBase=DAI-Pizzas;Trusted_Connection=True;";


    public static List<Pizzas> GetAll()
    {

        string sqlQuery;

        List<Pizzas> returnList;

        returnList = new List<Pizzas>();

        using (SqlConnection BDPizzas = new SqlConnection(CONNECTION_STRING))
        {

            sqlQuery = "SELECT Id, Nombre, LibreGluten, Importe, Descripcion FROM PIZZAS";

            returnList = BDPizzas.Query<Pizzas>(sqlQuery).ToList();

        }

        return returnList;

    }
    public static Pizzas GetById(int id)
    {

        string sqlQuery;

        Pizzas returnEntity = null;

        sqlQuery = "SELECT Id, Nombre, LibreGluten, Importe, Descripcion FROM Pizzas ";

        sqlQuery += "WHERE Id = @idPizza";

        using (SqlConnection BDPizzas = new SqlConnection(CONNECTION_STRING))
        {

            returnEntity = BDPizzas.QueryFirstOrDefault<Pizzas>(sqlQuery, new { idPizza = id });

        }

        return returnEntity;

    }
    public static int Insert(Pizzas pizza)
    {

        string sqlQuery;

        int intRowsAffected = 0;

        sqlQuery = "INSERT INTO Pizzas (";

        sqlQuery += " Nombre , LibreGluten , Importe , Descripcion";

        sqlQuery += ") VALUES (";

        sqlQuery += " @nombre , @libreGluten , @importe , @descripcion";

        sqlQuery += ")";

        using (SqlConnection BDPizzas = new SqlConnection(CONNECTION_STRING))
        {

            intRowsAffected = BDPizzas.Execute(sqlQuery, new
            {

                nombre = pizza.Nombre,

                libreGluten =
            pizza.LibreGluten,

                importe = pizza.Importe,

                descripcion =
            pizza.Descripcion

            }

            );

        }

        return intRowsAffected;
    }
    public static int UpdateById(Pizzas pizza)
    {

        string sqlQuery;

        int intRowsAffected = 0;

        sqlQuery = "UPDATE Pizzas SET ";

        sqlQuery += " Nombre = @nombre, ";

        sqlQuery += " LibreGluten = @libreGluten, ";

        sqlQuery += " Importe = @importe, ";

        sqlQuery += " Descripcion = @descripcion ";

        sqlQuery += "WHERE Id = @idPizza";

        using (var BDPizzas = new SqlConnection(CONNECTION_STRING))
        {

            intRowsAffected = BDPizzas.Execute(sqlQuery, new
            {

                idPizza = pizza.IdPizza,

                nombre = pizza.Nombre,

                libreGluten = pizza.LibreGluten,

                importe = pizza.Importe,

                descripcion = pizza.Descripcion

            }

            );

        }

        return intRowsAffected;

    }
    public static int DeleteById(int id)
    {

        string sqlQuery;

        int intRowsAffected = 0;

        sqlQuery = "DELETE FROM Pizzas WHERE Id = @idPizza";

        using (SqlConnection BDPizzas = new SqlConnection(CONNECTION_STRING))
        {

            intRowsAffected = BDPizzas.Execute(sqlQuery, new { idPizza = id });

        }

        return intRowsAffected;

    }
}