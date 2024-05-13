using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class Recipe
    {
    public int MovieID {get;set;}
    public string Title {get;set;}
    public string Description {get;set;}
    public DateTime ReleaseDate {get;set;}
    public string Genre {get;set;}

    public List<Review>? Reviews {get;set;}
    }

}