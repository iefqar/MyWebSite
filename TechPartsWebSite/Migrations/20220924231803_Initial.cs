using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechPartsWebSite.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.CreateTable(
                name: "stk_familia",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    master_formula = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    master_receta = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    master_especif = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    master_proceso = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    orden = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stk_familia", x => x.id);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "stk_grupo",
                columns: table => new
                {
                    grupo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    orden = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.grupo);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "stk_lista",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    moneda = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    iva_incluido = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'0'"),
                    alicuota = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    decimales = table.Column<int>(type: "int(1)", nullable: true, defaultValueSql: "'2'"),
                    decimales_costo = table.Column<int>(type: "int(1)", nullable: true),
                    redondeo_gcia = table.Column<decimal>(type: "decimal(6,4)", precision: 6, scale: 4, nullable: true),
                    redondeo_pvta = table.Column<decimal>(type: "decimal(6,4)", precision: 6, scale: 4, nullable: true),
                    redondeo_total = table.Column<decimal>(type: "decimal(6,4)", precision: 6, scale: 4, nullable: true),
                    round = table.Column<string>(type: "enum('ROUND','FLOOR','CEIL')", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    fecha = table.Column<DateOnly>(type: "date", nullable: true),
                    orden = table.Column<int>(type: "int(11)", nullable: true),
                    lista_padre = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    visible = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'1'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stk_lista", x => x.id);
                    table.ForeignKey(
                        name: "stk_lista_ibfk_2",
                        column: x => x.lista_padre,
                        principalTable: "stk_lista",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "vta_ajuste",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    tipo = table.Column<string>(type: "enum('COMPROBANTE','FACTURA','COBRO')", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    porcentaje = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    importe = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: true),
                    cantidad = table.Column<decimal>(type: "decimal(11,4)", precision: 11, scale: 4, nullable: true),
                    orden = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vta_ajuste", x => x.id);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "stk_subgrupo",
                columns: table => new
                {
                    subgrupo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValueSql: "''", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    grupo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    orden = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.subgrupo);
                    table.ForeignKey(
                        name: "stk_subgrupo_ibfk_1",
                        column: x => x.grupo,
                        principalTable: "stk_grupo",
                        principalColumn: "grupo",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "vta_cliente",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    razon_social = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    nombre_fantasia = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    grupo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    tipo_documento = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    numero_documento = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    numero_ib = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    condicion_iva = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    actividad = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    direccion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    localidad = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    provincia = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    pais = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    cpa = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    telefono = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    webpage = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    contacto = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    latitud = table.Column<decimal>(type: "decimal(17,14)", precision: 17, scale: 14, nullable: true),
                    longitud = table.Column<decimal>(type: "decimal(17,14)", precision: 17, scale: 14, nullable: true),
                    fecha_alta = table.Column<DateOnly>(type: "date", nullable: true),
                    fecha_baja = table.Column<DateOnly>(type: "date", nullable: true),
                    orden = table.Column<int>(type: "int(11)", nullable: true),
                    nota = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    observaciones = table.Column<string>(type: "text", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    tipo = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    letra = table.Column<string>(type: "char(1)", fixedLength: true, maxLength: 1, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    punto = table.Column<short>(type: "smallint(5)", nullable: true),
                    modelo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    tipo_n = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    letra_n = table.Column<string>(type: "char(1)", fixedLength: true, maxLength: 1, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    punto_n = table.Column<short>(type: "smallint(5)", nullable: true),
                    modelo_n = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    moneda = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    lista = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    ajuste_lista = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    ajuste_lista_n = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    ajuste_tipo = table.Column<string>(type: "enum('PORCENTUAL','AUMENTO','GANANCIA','CONIVA','SINIVA')", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    ajuste_tipo_n = table.Column<string>(type: "enum('PORCENTUAL','AUMENTO','GANANCIA','CONIVA','SINIVA')", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    ajuste = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    ajuste_n = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    rubro = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    condicion_venta = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    condicion_venta_n = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    destino = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    transporte = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    trabajador = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    comision_venta = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: true),
                    comision_venta0 = table.Column<decimal>(name: "comision_venta$", type: "decimal(8,2)", precision: 8, scale: 2, nullable: true),
                    comision_cobro = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: true),
                    comision_cobro0 = table.Column<decimal>(name: "comision_cobro$", type: "decimal(8,2)", precision: 8, scale: 2, nullable: true),
                    comprobante_imp = table.Column<string>(type: "enum('MANUAL','AUTOMATICO')", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    comprobante_adj = table.Column<string>(type: "enum('MANUAL','AUTOMATICO')", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    pago_electronico = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    fex_idimpositivo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    obs_factura = table.Column<string>(type: "text", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    ctacte_saldo = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: true),
                    ctacte_fecha = table.Column<DateOnly>(type: "date", nullable: true),
                    ctacte_limite = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: true),
                    ctacte_saldo_n = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: true),
                    ctacte_fecha_n = table.Column<DateOnly>(type: "date", nullable: true),
                    ctacte_limite_n = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: true),
                    modelo_asiento = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    modelo_asiento_cobro = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    color = table.Column<ulong>(type: "bit(1)", nullable: true, defaultValueSql: "b'1'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vta_cliente", x => x.id);
                    table.ForeignKey(
                        name: "vta_cliente_ibfk_6",
                        column: x => x.lista,
                        principalTable: "stk_lista",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "vta_combo",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    grupo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    fecha = table.Column<DateOnly>(type: "date", nullable: true),
                    foto = table.Column<byte[]>(type: "blob", nullable: true),
                    moneda = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    cotizacion = table.Column<decimal>(type: "decimal(9,3)", precision: 9, scale: 3, nullable: true, defaultValueSql: "'1.000'"),
                    lista = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    ajuste_lista = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    ajuste_tipo = table.Column<string>(type: "enum('PORCENTUAL','AUMENTO','GANANCIA','CONIVA','SINIVA')", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    ajuste = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    observaciones = table.Column<string>(type: "text", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    neto = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: true),
                    exento = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: true),
                    nogravado = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: true),
                    iva = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: true),
                    total = table.Column<decimal>(type: "decimal(13,2)", precision: 13, scale: 2, nullable: true),
                    orden = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vta_combo", x => x.id);
                    table.ForeignKey(
                        name: "vta_combo_ibfk_2",
                        column: x => x.lista,
                        principalTable: "stk_lista",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "vta_ajuste_item",
                columns: table => new
                {
                    tipo = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: false, defaultValueSql: "''", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    comprobante = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false, defaultValueSql: "''", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    linea = table.Column<int>(type: "int(11)", nullable: false),
                    ajuste = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false, defaultValueSql: "''", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    porcentaje = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    importe = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: true),
                    cantidad = table.Column<decimal>(type: "decimal(11,4)", precision: 11, scale: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.tipo, x.comprobante, x.linea, x.ajuste })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });
                    table.ForeignKey(
                        name: "vta_ajuste_item_ibfk_2",
                        column: x => x.ajuste,
                        principalTable: "vta_ajuste",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "stk_item",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    descripcion = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    presentacion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    grupo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    subgrupo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    tipo = table.Column<string>(type: "enum('PT','SE','MP','CP','S','F')", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    barcode = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    familia = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    master = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    unidad = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    decimales = table.Column<int>(type: "int(1)", nullable: true),
                    peso = table.Column<decimal>(type: "decimal(9,4)", precision: 9, scale: 4, nullable: true),
                    stock_minimo = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true, defaultValueSql: "'0.00'"),
                    vencimiento = table.Column<DateOnly>(type: "date", nullable: true),
                    vto_meses = table.Column<int>(type: "int(11)", nullable: true),
                    rubro = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    factor_vta = table.Column<decimal>(type: "decimal(16,8)", precision: 16, scale: 8, nullable: true),
                    unidad_vta = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    decimales_vta = table.Column<int>(type: "int(1)", nullable: true),
                    auxiliar1_vta = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    unidad1_vta = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    decimales1_vta = table.Column<int>(type: "int(1)", nullable: true),
                    auxiliar2_vta = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    unidad2_vta = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    decimales2_vta = table.Column<int>(type: "int(1)", nullable: true),
                    auxiliar3_vta = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    unidad3_vta = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    decimales3_vta = table.Column<int>(type: "int(1)", nullable: true),
                    factor_cmp = table.Column<decimal>(type: "decimal(16,8)", precision: 16, scale: 8, nullable: true),
                    unidad_cmp = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    decimales_cmp = table.Column<int>(type: "int(1)", nullable: true),
                    auxiliar1_cmp = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    unidad1_cmp = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    decimales1_cmp = table.Column<int>(type: "int(1)", nullable: true),
                    auxiliar2_cmp = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    unidad2_cmp = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    decimales2_cmp = table.Column<int>(type: "int(1)", nullable: true),
                    auxiliar3_cmp = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    unidad3_cmp = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    decimales3_cmp = table.Column<int>(type: "int(1)", nullable: true),
                    unidad_fex = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    item_matrix = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    unidad_matrix = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    foto = table.Column<byte[]>(type: "blob", nullable: true),
                    observaciones = table.Column<string>(type: "text", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    stock = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'1'"),
                    compra = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'1'"),
                    venta = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'1'"),
                    orden = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stk_item", x => x.id);
                    table.ForeignKey(
                        name: "stk_item_ibfk_1",
                        column: x => x.grupo,
                        principalTable: "stk_grupo",
                        principalColumn: "grupo",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "stk_item_ibfk_2",
                        column: x => x.subgrupo,
                        principalTable: "stk_subgrupo",
                        principalColumn: "subgrupo",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "stk_item_ibfk_3",
                        column: x => x.familia,
                        principalTable: "stk_familia",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "stk_existencia",
                columns: table => new
                {
                    deposito = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, defaultValueSql: "''", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    item = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, defaultValueSql: "''", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    cantidad = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true, defaultValueSql: "'0.0000'"),
                    produccion = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true, defaultValueSql: "'0.0000'"),
                    comprometido = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true, defaultValueSql: "'0.0000'"),
                    ubicacion = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.deposito, x.item })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "stk_existencia_ibfk_2",
                        column: x => x.item,
                        principalTable: "stk_item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "stk_formula",
                columns: table => new
                {
                    item = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, defaultValueSql: "''", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    componente = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, defaultValueSql: "''", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    cantidad_item = table.Column<decimal>(type: "decimal(16,8)", precision: 16, scale: 8, nullable: true, defaultValueSql: "'1.00000000'"),
                    cantidad_comp = table.Column<decimal>(type: "decimal(16,8)", precision: 16, scale: 8, nullable: true, defaultValueSql: "'1.00000000'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.item, x.componente })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "stk_formula_ibfk_1",
                        column: x => x.item,
                        principalTable: "stk_item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "stk_formula_ibfk_2",
                        column: x => x.componente,
                        principalTable: "stk_item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "stk_precio",
                columns: table => new
                {
                    lista = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, defaultValueSql: "''", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    item = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, defaultValueSql: "''", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    cantidad = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: false),
                    precio = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true, defaultValueSql: "'0.0000'"),
                    aumento = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: true),
                    ganancia = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: true),
                    preciovta = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true),
                    alicuota = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    moneda = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    calculo = table.Column<string>(type: "enum('UNIDAD','CANTIDAD','PRECIO')", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    ajuste = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    ajuste_precio = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: true),
                    fecha = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.lista, x.item, x.cantidad })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
                    table.ForeignKey(
                        name: "stk_precio_ibfk_1",
                        column: x => x.lista,
                        principalTable: "stk_lista",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "stk_precio_ibfk_2",
                        column: x => x.item,
                        principalTable: "stk_item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "vta_combo_item",
                columns: table => new
                {
                    combo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, defaultValueSql: "''", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    linea = table.Column<int>(type: "int(11)", nullable: false),
                    item = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    descripcion = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    cantidad = table.Column<decimal>(type: "decimal(11,4)", precision: 11, scale: 4, nullable: true, defaultValueSql: "'0.0000'"),
                    precio = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: true, defaultValueSql: "'0.0000'"),
                    ivainc = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    decimales = table.Column<int>(type: "int(1)", nullable: true),
                    importe = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: true, defaultValueSql: "'0.00'"),
                    alicuota = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    iva = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: true),
                    ajuste = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    ajuste_neto = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: true),
                    ajuste_iva = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: true),
                    moneda = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    cotizacion = table.Column<decimal>(type: "decimal(9,3)", precision: 9, scale: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.combo, x.linea })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "vta_combo_item_ibfk_1",
                        column: x => x.combo,
                        principalTable: "vta_combo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "vta_combo_item_ibfk_2",
                        column: x => x.item,
                        principalTable: "stk_item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateIndex(
                name: "item",
                table: "stk_existencia",
                column: "item");

            migrationBuilder.CreateIndex(
                name: "componente",
                table: "stk_formula",
                column: "componente");

            migrationBuilder.CreateIndex(
                name: "familia",
                table: "stk_item",
                column: "familia");

            migrationBuilder.CreateIndex(
                name: "grupo",
                table: "stk_item",
                column: "grupo");

            migrationBuilder.CreateIndex(
                name: "orden_index_stk_item",
                table: "stk_item",
                columns: new[] { "orden", "id" });

            migrationBuilder.CreateIndex(
                name: "rubro",
                table: "stk_item",
                column: "rubro");

            migrationBuilder.CreateIndex(
                name: "subgrupo",
                table: "stk_item",
                column: "subgrupo");

            migrationBuilder.CreateIndex(
                name: "lista_padre",
                table: "stk_lista",
                column: "lista_padre");

            migrationBuilder.CreateIndex(
                name: "moneda",
                table: "stk_lista",
                column: "moneda");

            migrationBuilder.CreateIndex(
                name: "item1",
                table: "stk_precio",
                column: "item");

            migrationBuilder.CreateIndex(
                name: "moneda1",
                table: "stk_precio",
                column: "moneda");

            migrationBuilder.CreateIndex(
                name: "grupo1",
                table: "stk_subgrupo",
                column: "grupo");

            migrationBuilder.CreateIndex(
                name: "ajuste",
                table: "vta_ajuste_item",
                column: "ajuste");

            migrationBuilder.CreateIndex(
                name: "condicion_iva",
                table: "vta_cliente",
                column: "condicion_iva");

            migrationBuilder.CreateIndex(
                name: "condicion_venta",
                table: "vta_cliente",
                column: "condicion_venta");

            migrationBuilder.CreateIndex(
                name: "condicion_venta_n",
                table: "vta_cliente",
                column: "condicion_venta_n");

            migrationBuilder.CreateIndex(
                name: "destino",
                table: "vta_cliente",
                column: "destino");

            migrationBuilder.CreateIndex(
                name: "lista",
                table: "vta_cliente",
                column: "lista");

            migrationBuilder.CreateIndex(
                name: "modelo_asiento",
                table: "vta_cliente",
                column: "modelo_asiento");

            migrationBuilder.CreateIndex(
                name: "modelo_asiento_cobro",
                table: "vta_cliente",
                column: "modelo_asiento_cobro");

            migrationBuilder.CreateIndex(
                name: "moneda2",
                table: "vta_cliente",
                column: "moneda");

            migrationBuilder.CreateIndex(
                name: "provincia",
                table: "vta_cliente",
                column: "provincia");

            migrationBuilder.CreateIndex(
                name: "rubro1",
                table: "vta_cliente",
                column: "rubro");

            migrationBuilder.CreateIndex(
                name: "tipo",
                table: "vta_cliente",
                columns: new[] { "tipo", "letra", "modelo" });

            migrationBuilder.CreateIndex(
                name: "tipo_n",
                table: "vta_cliente",
                columns: new[] { "tipo_n", "letra_n", "modelo_n" });

            migrationBuilder.CreateIndex(
                name: "trabajador",
                table: "vta_cliente",
                column: "trabajador");

            migrationBuilder.CreateIndex(
                name: "transporte",
                table: "vta_cliente",
                column: "transporte");

            migrationBuilder.CreateIndex(
                name: "lista1",
                table: "vta_combo",
                column: "lista");

            migrationBuilder.CreateIndex(
                name: "moneda3",
                table: "vta_combo",
                column: "moneda");

            migrationBuilder.CreateIndex(
                name: "item2",
                table: "vta_combo_item",
                column: "item");

            migrationBuilder.CreateIndex(
                name: "moneda4",
                table: "vta_combo_item",
                column: "moneda");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stk_existencia");

            migrationBuilder.DropTable(
                name: "stk_formula");

            migrationBuilder.DropTable(
                name: "stk_precio");

            migrationBuilder.DropTable(
                name: "vta_ajuste_item");

            migrationBuilder.DropTable(
                name: "vta_cliente");

            migrationBuilder.DropTable(
                name: "vta_combo_item");

            migrationBuilder.DropTable(
                name: "vta_ajuste");

            migrationBuilder.DropTable(
                name: "vta_combo");

            migrationBuilder.DropTable(
                name: "stk_item");

            migrationBuilder.DropTable(
                name: "stk_lista");

            migrationBuilder.DropTable(
                name: "stk_subgrupo");

            migrationBuilder.DropTable(
                name: "stk_familia");

            migrationBuilder.DropTable(
                name: "stk_grupo");
        }
    }
}
