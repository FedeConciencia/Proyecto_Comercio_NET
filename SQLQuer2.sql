use CATALOGO_DB;

DELETE FROM ARTICULOS;

SELECT * FROM ARTICULOS;
SELECT * FROM MARCAS;
SELECT * FROM CATEGORIAS;

INSERT INTO MARCAS (Descripcion) VALUES ('Xiaomi');

DBCC CHECKIDENT (ARTICULOS, RESEED, 0)

INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) VALUES
('G14','Moto G14 4G','Disfrutá de películas, programas, juegos y videollamadas', 5, 1, 'https://tiendaonline.movistar.com.ar/media/catalog/product/cache/1d01ed3f1ecf95fcf479279f9ae509ad/m/o/motog14-steel-charger_2.png', 269.999),
('A14','Galaxy A14 4G','Un estilizado diseño minimalista se fusiona con toques de color.', 1, 1, 'https://tiendaonline.movistar.com.ar/media/catalog/product/cache/1d01ed3f1ecf95fcf479279f9ae509ad/s/a/samsung-a14-front_1.png', 179.999),
('R11','Redmi Note 11','Sumérgete en un mundo maravilloso', 6, 1, 'https://tiendaonline.movistar.com.ar/media/catalog/product/cache/1d01ed3f1ecf95fcf479279f9ae509ad/r/e/redmi-11-note_1.png', 362.000),
('R12','Redmi 12C','El Redmi 12C cuenta con una gran pantalla HD', 6, 1, 'https://tiendaonline.movistar.com.ar/media/catalog/product/cache/1d01ed3f1ecf95fcf479279f9ae509ad/r/e/redmi-12c_1_2.png', 279.000),
('G13','Moto G13 128Gb 4G','Alta definición con la tecnología de pantalla FHD', 5, 1, 'https://tiendaonline.movistar.com.ar/media/catalog/product/cache/1d01ed3f1ecf95fcf479279f9ae509ad/m/o/moto-g13_2.png', 284.000),
('A14','Galaxy A14 4G','Galaxy A14 y experimentá todo en colores verdaderos', 1, 1, 'https://tiendaonline.movistar.com.ar/media/catalog/product/cache/1d01ed3f1ecf95fcf479279f9ae509ad/s/a/samsung-a14-front_1.png', 269.000),
('G32','Moto G32 6GB RAM','Cambiá de aplicaciones, desplazate por la Web', 5, 1, 'https://tiendaonline.movistar.com.ar/media/catalog/product/cache/1d01ed3f1ecf95fcf479279f9ae509ad/m/o/moto-g32_5_1.png', 360.000);

UPDATE ARTICULOS SET Precio = 360.999 WHERE Id = 8;


ALTER TABLE ARTICULOS
ADD FOREIGN KEY (IdCategoria) REFERENCES CATEGORIAS (Id);

SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, a.ImagenUrl, a.Precio, c.Id AS Id_Cat, c.Descripcion AS Categoria, m.Id AS Id_Marc, m.Descripcion AS Modelo FROM 
ARTICULOS AS a INNER JOIN CATEGORIAS AS c ON c.Id = a.IdCategoria INNER JOIN MARCAS AS m ON m.Id = a.IdMarca;

