# WsApiexamen
Examen Selección Bansi de Miguel Angel Sanchez Vazquez del Mercado

El proyecto contiene dos folders:

El folder BDD contiene el Script de la base de Datos y los Script de los Stored Procedures utilizados

El folder Source contiene un WebService que usa la BDD, un DLL que puede llamar al WebService o a los Store Procedures y un proyecto WPF para la pantalla donde se puede actualizar los datos.

Para acesar la BDD se debe de modificar los valores del "ConnectionStrings" en el archivo "appsettings.json" del Proyecto "WsApiexamen"

Y la variable _connectionString de la clase "StoreProcedure" del proyecto "ApiExamen"
