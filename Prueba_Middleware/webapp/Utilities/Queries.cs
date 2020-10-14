using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartAdminMvc.Utilities
{
    public class Queries
    {
        public static string GetOrdenMantenimiento = @"SELECT
                                                        --Inf Cliente
                                                         CL.NOMBRE Nombre,
                                                         CONCAT( MN.NOMBRE, ', ', DP.NOMBRE) Ciudad,
                                                         CL.TELEFONO1 Telefono1,
                                                         CL.TELEFONO2 Telefono2,
                                                         CL.EMAIL Email,
                                                         --Inf Vehiculo
                                                         V.NUMSERIE NumeroSerie,
                                                         V.NUMPLACA Placa,
                                                         V.ANO Ano,
                                                         V.COLOR Color,
                                                         V.LLAVE Llave,
                                                         V.NUMMOTOR Motor,
                                                         PROD.NOMBRE Modelo,
                                                         --Detalle Revision
                                                         R.FECHA Fecha,
                                                         R.HORA Hora,
                                                         ASE.NOMBRE Asesor,
                                                         MEC.NOMBRE Mecanico,
                                                         ASISM.NOMBRE Asistente,
                                                         PAG.DESCRIPCION TipoPago
                                                        FROM TR_REVISION R
                                                        INNER JOIN [dbo].[TR_CITAS] CT ON R.ID_CITA = CT.ID_CITA
                                                        INNER JOIN [dbo].[TR_VEHICULOS] V ON CT.ID_VEHICULO = V.ID_VEHICULO
                                                        INNER JOIN [dbo].[INV_PRODUCTOS] PROD ON V.COD_PRODUCTO = PROD.COD_PRODUCTO
                                                        INNER JOIN [dbo].[TR_CLIENTES] CL ON V.ID_CLIENTE = CL.ID_CLIENTE
                                                        INNER JOIN [dbo].[AXL_MUNICIPIOS] MN ON CL.COD_MUNICIPIO = MN.COD_MUNICIPIO AND CL.COD_DEPARTAMENTO = MN.COD_DEPARTAMENTO
                                                        INNER JOIN [dbo].[AXL_DEPARTAMENTOS] DP ON CL.COD_DEPARTAMENTO = DP.COD_DEPARTAMENTO
                                                        INNER JOIN [dbo].[TR_COLABORADOR] ASE ON R.ASESOR = ASE.ID_COLABORADOR 
                                                        INNER JOIN [dbo].[TR_COLABORADOR] MEC ON R.MECANICO = MEC.ID_COLABORADOR
                                                        INNER JOIN [dbo].[TR_COLABORADOR] ASISM ON R.MECANICO_ASISTENTE = ASISM.ID_COLABORADOR
                                                        INNER JOIN [dbo].[TR_TIPO_PAGO] PAG ON R.TIPO_PAGO = PAG.ID
                                                        WHERE R.ID_REVISION = {0}";
    }
}