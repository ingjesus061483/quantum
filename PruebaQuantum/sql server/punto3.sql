select SUM(valorunitario)subtotates ,sum(valorunitarioIva) totalVentas,fechaVenta 
from facturaencabezados inner join facturadetalles on facturaencabezados.id=facturaDetalles .idfactura
where fechaVenta between  DATEADD (day,-10,getdate()) and getdate()
group by fechaVenta