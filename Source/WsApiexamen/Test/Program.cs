// See https://aka.ms/new-console-template for more information

using ApiExamen;
using BdiExamen.Dtos;

ClsExamen.CallWebService(false);

var response = await ClsExamen.AgregarExamenAsync(new ExamenDto
{
    idExamen = 21,
    Descripcion = "Descripcion 9",
    Nombre = "Nombre 9"
});

response = await ClsExamen.ActualizarExamenAsync(new ExamenDto
{
    idExamen = 21,
    Descripcion = "Descripcion 21",
    Nombre = "Nombre 21"
});

response = await ClsExamen.ConsultarExamenAsync(21);

response = await ClsExamen.EliminarExamenAsync(21);

Console.WriteLine("Todo Ok!");
