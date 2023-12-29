use CATALOGO_DB;

SELECT * FROM ARTICULOS;
SELECT * FROM CATEGORIAS;
SELECT * FROM MARCAS;


SELECT Id, Codigo, Nombre, Descripcion, ImagenUrl, Precio FROM ARTICULOS;


SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, a.ImagenUrl, a.Precio, c.Id AS Id_Cat, c.Descripcion AS Categoria, m.Id AS Id_Marc, m.Descripcion AS Modelo FROM ARTICULOS AS a, CATEGORIAS AS c, MARCAS AS m WHERE c.Id = a.IdCategoria AND m.Id = a.IdMarca AND a.Nombre = 'Play 4';

SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, a.ImagenUrl, a.Precio, c.Id AS Id_Cat, c.Descripcion AS Categoria, m.Id AS Id_Marc, m.Descripcion AS Modelo FROM ARTICULOS AS a, CATEGORIAS AS c, MARCAS AS m WHERE c.Id = a.IdCategoria AND m.Id = a.IdMarca;