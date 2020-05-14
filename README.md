Inventario de productos (PRODUCTS) Stefano Sossi, Gabriel Acosta, Josue Cardozo, Pedro Gonzales. (GRUPO 2)

Dado que la empresa se dedica a vender poleras deportivas, me gustaría manejar el inventario de la sgte
forma:

Estructura (MASTER y REPOSITORIO GIT) ---<Gabriel Acosta>

BusinessLogic --<Stefano Sossi>
Controllers --<Gabriel Acosta>
Database --<Josue Cardozo>
DTOModels --<Stafano Sossi, Pedro Gonzales>

● Operaciones básicas (CRUD) para tener acceso a mis productos
CREATE 
READ 
UPDATE 
DELETE 
----<Josue Cardozo>



● Los datos de cada producto que me gustaría almacenar son:
    o Nombre del Producto
    o Tipos de Producto: SOCCER o BASKET
    o Código del Producto (autogenerado, único)

▪ Si es un artículo de futbol: SOCCER-XXX (donde XXX es el número correlativo
según se van agregando items)

▪ Si es un artículo de Basket: BASKET-XXX (donde XXX es el número correlativo
según se van agregando items)
    o Stock, número de items en almacén