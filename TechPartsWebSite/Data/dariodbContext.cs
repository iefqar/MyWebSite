using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TechPartsWebSite.Entities.SistemaNacional;

namespace TechPartsWebSite.Data
{
    public partial class dariodbContext : DbContext
    {
        public dariodbContext()
        {
        }

        public dariodbContext(DbContextOptions<dariodbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StkExistencium> StkExistencia { get; set; } = null!;
        public virtual DbSet<StkFamilium> StkFamilia { get; set; } = null!;
        public virtual DbSet<StkFormula> StkFormulas { get; set; } = null!;
        public virtual DbSet<StkGrupo> StkGrupos { get; set; } = null!;
        public virtual DbSet<StkItem> StkItems { get; set; } = null!;
        public virtual DbSet<StkListum> StkLista { get; set; } = null!;
        public virtual DbSet<StkPrecio> StkPrecios { get; set; } = null!;
        public virtual DbSet<StkSubgrupo> StkSubgrupos { get; set; } = null!;
        public virtual DbSet<VtaAjuste> VtaAjustes { get; set; } = null!;
        public virtual DbSet<VtaAjusteItem> VtaAjusteItems { get; set; } = null!;
        public virtual DbSet<VtaCliente> VtaClientes { get; set; } = null!;
        public virtual DbSet<VtaCombo> VtaCombos { get; set; } = null!;
        public virtual DbSet<VtaComboItem> VtaComboItems { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("name=DefaultConnection", ServerVersion.Parse("5.7.38-mysql"));
            }
        }

        //todo esto es Api Fluente. reemplaza a las anotations (pe: [Key]) en las entidades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<StkExistencium>(entity =>
            {
                entity.HasKey(e => new { e.Deposito, e.Item })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("stk_existencia");

                entity.HasIndex(e => e.Item, "item");

                entity.Property(e => e.Deposito)
                    .HasMaxLength(20)
                    .HasColumnName("deposito")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Item)
                    .HasMaxLength(20)
                    .HasColumnName("item")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Cantidad)
                    .HasPrecision(14, 4)
                    .HasColumnName("cantidad")
                    .HasDefaultValueSql("'0.0000'");

                entity.Property(e => e.Comprometido)
                    .HasPrecision(14, 4)
                    .HasColumnName("comprometido")
                    .HasDefaultValueSql("'0.0000'");

                entity.Property(e => e.Produccion)
                    .HasPrecision(14, 4)
                    .HasColumnName("produccion")
                    .HasDefaultValueSql("'0.0000'");

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(20)
                    .HasColumnName("ubicacion");

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.StkExistencia)
                    .HasForeignKey(d => d.Item)
                    .HasConstraintName("stk_existencia_ibfk_2");
            });

            modelBuilder.Entity<StkFamilium>(entity =>
            {
                entity.ToTable("stk_familia");

                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .HasColumnName("descripcion");

                entity.Property(e => e.MasterEspecif)
                    .HasMaxLength(5)
                    .HasColumnName("master_especif");

                entity.Property(e => e.MasterFormula)
                    .HasMaxLength(5)
                    .HasColumnName("master_formula");

                entity.Property(e => e.MasterProceso)
                    .HasMaxLength(5)
                    .HasColumnName("master_proceso");

                entity.Property(e => e.MasterReceta)
                    .HasMaxLength(5)
                    .HasColumnName("master_receta");

                entity.Property(e => e.Orden)
                    .HasColumnType("int(11)")
                    .HasColumnName("orden");
            });

            modelBuilder.Entity<StkFormula>(entity =>
            {
                entity.HasKey(e => new { e.Item, e.Componente })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("stk_formula");

                entity.HasIndex(e => e.Componente, "componente");

                entity.Property(e => e.Item)
                    .HasMaxLength(20)
                    .HasColumnName("item")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Componente)
                    .HasMaxLength(20)
                    .HasColumnName("componente")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CantidadComp)
                    .HasPrecision(16, 8)
                    .HasColumnName("cantidad_comp")
                    .HasDefaultValueSql("'1.00000000'");

                entity.Property(e => e.CantidadItem)
                    .HasPrecision(16, 8)
                    .HasColumnName("cantidad_item")
                    .HasDefaultValueSql("'1.00000000'");

                entity.HasOne(d => d.ComponenteNavigation)
                    .WithMany(p => p.StkFormulaComponenteNavigations)
                    .HasForeignKey(d => d.Componente)
                    .HasConstraintName("stk_formula_ibfk_2");

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.StkFormulaItemNavigations)
                    .HasForeignKey(d => d.Item)
                    .HasConstraintName("stk_formula_ibfk_1");
            });

            modelBuilder.Entity<StkGrupo>(entity =>
            {
                entity.HasKey(e => e.Grupo)
                    .HasName("PRIMARY");

                entity.ToTable("stk_grupo");

                entity.Property(e => e.Grupo)
                    .HasMaxLength(50)
                    .HasColumnName("grupo");

                entity.Property(e => e.Orden)
                    .HasColumnType("int(11)")
                    .HasColumnName("orden");
            });

            modelBuilder.Entity<StkItem>(entity =>
            {
                entity.ToTable("stk_item");

                entity.HasIndex(e => e.Familia, "familia");

                entity.HasIndex(e => e.Grupo, "grupo");

                entity.HasIndex(e => new { e.Orden, e.Id }, "orden_index_stk_item");

                entity.HasIndex(e => e.Rubro, "rubro");

                entity.HasIndex(e => e.Subgrupo, "subgrupo");

                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .HasColumnName("id");

                entity.Property(e => e.Auxiliar1Cmp)
                    .HasMaxLength(20)
                    .HasColumnName("auxiliar1_cmp");

                entity.Property(e => e.Auxiliar1Vta)
                    .HasMaxLength(20)
                    .HasColumnName("auxiliar1_vta");

                entity.Property(e => e.Auxiliar2Cmp)
                    .HasMaxLength(20)
                    .HasColumnName("auxiliar2_cmp");

                entity.Property(e => e.Auxiliar2Vta)
                    .HasMaxLength(20)
                    .HasColumnName("auxiliar2_vta");

                entity.Property(e => e.Auxiliar3Cmp)
                    .HasMaxLength(20)
                    .HasColumnName("auxiliar3_cmp");

                entity.Property(e => e.Auxiliar3Vta)
                    .HasMaxLength(20)
                    .HasColumnName("auxiliar3_vta");

                entity.Property(e => e.Barcode)
                    .HasMaxLength(30)
                    .HasColumnName("barcode");

                entity.Property(e => e.Compra)
                    .HasColumnName("compra")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Decimales)
                    .HasColumnType("int(1)")
                    .HasColumnName("decimales");

                entity.Property(e => e.Decimales1Cmp)
                    .HasColumnType("int(1)")
                    .HasColumnName("decimales1_cmp");

                entity.Property(e => e.Decimales1Vta)
                    .HasColumnType("int(1)")
                    .HasColumnName("decimales1_vta");

                entity.Property(e => e.Decimales2Cmp)
                    .HasColumnType("int(1)")
                    .HasColumnName("decimales2_cmp");

                entity.Property(e => e.Decimales2Vta)
                    .HasColumnType("int(1)")
                    .HasColumnName("decimales2_vta");

                entity.Property(e => e.Decimales3Cmp)
                    .HasColumnType("int(1)")
                    .HasColumnName("decimales3_cmp");

                entity.Property(e => e.Decimales3Vta)
                    .HasColumnType("int(1)")
                    .HasColumnName("decimales3_vta");

                entity.Property(e => e.DecimalesCmp)
                    .HasColumnType("int(1)")
                    .HasColumnName("decimales_cmp");

                entity.Property(e => e.DecimalesVta)
                    .HasColumnType("int(1)")
                    .HasColumnName("decimales_vta");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("descripcion");

                entity.Property(e => e.FactorCmp)
                    .HasPrecision(16, 8)
                    .HasColumnName("factor_cmp");

                entity.Property(e => e.FactorVta)
                    .HasPrecision(16, 8)
                    .HasColumnName("factor_vta");

                entity.Property(e => e.Familia)
                    .HasMaxLength(20)
                    .HasColumnName("familia");

                entity.Property(e => e.Foto)
                    .HasColumnType("blob")
                    .HasColumnName("foto");

                entity.Property(e => e.Grupo)
                    .HasMaxLength(50)
                    .HasColumnName("grupo");

                entity.Property(e => e.ItemMatrix)
                    .HasMaxLength(128)
                    .HasColumnName("item_matrix");

                entity.Property(e => e.Master)
                    .HasMaxLength(20)
                    .HasColumnName("master");

                entity.Property(e => e.Observaciones)
                    .HasColumnType("text")
                    .HasColumnName("observaciones");

                entity.Property(e => e.Orden)
                    .HasColumnType("int(11)")
                    .HasColumnName("orden");

                entity.Property(e => e.Peso)
                    .HasPrecision(9, 4)
                    .HasColumnName("peso");

                entity.Property(e => e.Presentacion)
                    .HasMaxLength(100)
                    .HasColumnName("presentacion");

                entity.Property(e => e.Rubro)
                    .HasMaxLength(20)
                    .HasColumnName("rubro");

                entity.Property(e => e.Stock)
                    .HasColumnName("stock")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.StockMinimo)
                    .HasPrecision(10, 2)
                    .HasColumnName("stock_minimo")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Subgrupo)
                    .HasMaxLength(50)
                    .HasColumnName("subgrupo");

                entity.Property(e => e.Tipo)
                    .HasColumnType("enum('PT','SE','MP','CP','S','F')")
                    .HasColumnName("tipo");

                entity.Property(e => e.Unidad)
                    .HasMaxLength(5)
                    .HasColumnName("unidad");

                entity.Property(e => e.Unidad1Cmp)
                    .HasMaxLength(5)
                    .HasColumnName("unidad1_cmp");

                entity.Property(e => e.Unidad1Vta)
                    .HasMaxLength(5)
                    .HasColumnName("unidad1_vta");

                entity.Property(e => e.Unidad2Cmp)
                    .HasMaxLength(5)
                    .HasColumnName("unidad2_cmp");

                entity.Property(e => e.Unidad2Vta)
                    .HasMaxLength(5)
                    .HasColumnName("unidad2_vta");

                entity.Property(e => e.Unidad3Cmp)
                    .HasMaxLength(5)
                    .HasColumnName("unidad3_cmp");

                entity.Property(e => e.Unidad3Vta)
                    .HasMaxLength(5)
                    .HasColumnName("unidad3_vta");

                entity.Property(e => e.UnidadCmp)
                    .HasMaxLength(128)
                    .HasColumnName("unidad_cmp");

                entity.Property(e => e.UnidadFex)
                    .HasMaxLength(5)
                    .HasColumnName("unidad_fex");

                entity.Property(e => e.UnidadMatrix)
                    .HasMaxLength(128)
                    .HasColumnName("unidad_matrix");

                entity.Property(e => e.UnidadVta)
                    .HasMaxLength(5)
                    .HasColumnName("unidad_vta");

                entity.Property(e => e.Vencimiento).HasColumnName("vencimiento");

                entity.Property(e => e.Venta)
                    .HasColumnName("venta")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.VtoMeses)
                    .HasColumnType("int(11)")
                    .HasColumnName("vto_meses");

                entity.HasOne(d => d.FamiliaNavigation)
                    .WithMany(p => p.StkItems)
                    .HasForeignKey(d => d.Familia)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stk_item_ibfk_3");

                entity.HasOne(d => d.GrupoNavigation)
                    .WithMany(p => p.StkItems)
                    .HasForeignKey(d => d.Grupo)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stk_item_ibfk_1");

                entity.HasOne(d => d.SubgrupoNavigation)
                    .WithMany(p => p.StkItems)
                    .HasForeignKey(d => d.Subgrupo)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stk_item_ibfk_2");
            });

            modelBuilder.Entity<StkListum>(entity =>
            {
                entity.ToTable("stk_lista");

                entity.HasIndex(e => e.ListaPadre, "lista_padre");

                entity.HasIndex(e => e.Moneda, "moneda");

                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .HasColumnName("id");

                entity.Property(e => e.Alicuota)
                    .HasPrecision(5, 2)
                    .HasColumnName("alicuota");

                entity.Property(e => e.Decimales)
                    .HasColumnType("int(1)")
                    .HasColumnName("decimales")
                    .HasDefaultValueSql("'2'");

                entity.Property(e => e.DecimalesCosto)
                    .HasColumnType("int(1)")
                    .HasColumnName("decimales_costo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.IvaIncluido)
                    .HasColumnName("iva_incluido")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ListaPadre)
                    .HasMaxLength(20)
                    .HasColumnName("lista_padre");

                entity.Property(e => e.Moneda)
                    .HasMaxLength(5)
                    .HasColumnName("moneda");

                entity.Property(e => e.Orden)
                    .HasColumnType("int(11)")
                    .HasColumnName("orden");

                entity.Property(e => e.RedondeoGcia)
                    .HasPrecision(6, 4)
                    .HasColumnName("redondeo_gcia");

                entity.Property(e => e.RedondeoPvta)
                    .HasPrecision(6, 4)
                    .HasColumnName("redondeo_pvta");

                entity.Property(e => e.RedondeoTotal)
                    .HasPrecision(6, 4)
                    .HasColumnName("redondeo_total");

                entity.Property(e => e.Round)
                    .HasColumnType("enum('ROUND','FLOOR','CEIL')")
                    .HasColumnName("round");

                entity.Property(e => e.Visible)
                    .HasColumnName("visible")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.ListaPadreNavigation)
                    .WithMany(p => p.InverseListaPadreNavigation)
                    .HasForeignKey(d => d.ListaPadre)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stk_lista_ibfk_2");
            });

            modelBuilder.Entity<StkPrecio>(entity =>
            {
                entity.HasKey(e => new { e.Lista, e.Item, e.Cantidad })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("stk_precio");

                entity.HasIndex(e => e.Item, "item");

                entity.HasIndex(e => e.Moneda, "moneda");

                entity.Property(e => e.Lista)
                    .HasMaxLength(20)
                    .HasColumnName("lista")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Item)
                    .HasMaxLength(20)
                    .HasColumnName("item")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Cantidad)
                    .HasPrecision(12, 4)
                    .HasColumnName("cantidad");

                entity.Property(e => e.Ajuste)
                    .HasPrecision(5, 2)
                    .HasColumnName("ajuste");

                entity.Property(e => e.AjustePrecio)
                    .HasPrecision(11, 2)
                    .HasColumnName("ajuste_precio");

                entity.Property(e => e.Alicuota)
                    .HasPrecision(5, 2)
                    .HasColumnName("alicuota");

                entity.Property(e => e.Aumento)
                    .HasPrecision(6, 2)
                    .HasColumnName("aumento");

                entity.Property(e => e.Calculo)
                    .HasColumnType("enum('UNIDAD','CANTIDAD','PRECIO')")
                    .HasColumnName("calculo");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.Ganancia)
                    .HasPrecision(6, 2)
                    .HasColumnName("ganancia");

                entity.Property(e => e.Moneda)
                    .HasMaxLength(5)
                    .HasColumnName("moneda");

                entity.Property(e => e.Precio)
                    .HasPrecision(12, 4)
                    .HasColumnName("precio")
                    .HasDefaultValueSql("'0.0000'");

                entity.Property(e => e.Preciovta)
                    .HasPrecision(12, 4)
                    .HasColumnName("preciovta");

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.StkPrecios)
                    .HasForeignKey(d => d.Item)
                    .HasConstraintName("stk_precio_ibfk_2");

                entity.HasOne(d => d.ListaNavigation)
                    .WithMany(p => p.StkPrecios)
                    .HasForeignKey(d => d.Lista)
                    .HasConstraintName("stk_precio_ibfk_1");
            });

            modelBuilder.Entity<StkSubgrupo>(entity =>
            {
                entity.HasKey(e => e.Subgrupo)
                    .HasName("PRIMARY");

                entity.ToTable("stk_subgrupo");

                entity.HasIndex(e => e.Grupo, "grupo");

                entity.Property(e => e.Subgrupo)
                    .HasMaxLength(50)
                    .HasColumnName("subgrupo")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Grupo)
                    .HasMaxLength(50)
                    .HasColumnName("grupo");

                entity.Property(e => e.Orden)
                    .HasColumnType("int(11)")
                    .HasColumnName("orden");

                entity.HasOne(d => d.GrupoNavigation)
                    .WithMany(p => p.StkSubgrupos)
                    .HasForeignKey(d => d.Grupo)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stk_subgrupo_ibfk_1");
            });

            modelBuilder.Entity<VtaAjuste>(entity =>
            {
                entity.ToTable("vta_ajuste");

                entity.Property(e => e.Id)
                    .HasMaxLength(5)
                    .HasColumnName("id");

                entity.Property(e => e.Cantidad)
                    .HasPrecision(11, 4)
                    .HasColumnName("cantidad");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Importe)
                    .HasPrecision(11, 2)
                    .HasColumnName("importe");

                entity.Property(e => e.Orden)
                    .HasColumnType("int(11)")
                    .HasColumnName("orden");

                entity.Property(e => e.Porcentaje)
                    .HasPrecision(5, 2)
                    .HasColumnName("porcentaje");

                entity.Property(e => e.Tipo)
                    .HasColumnType("enum('COMPROBANTE','FACTURA','COBRO')")
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<VtaAjusteItem>(entity =>
            {
                entity.HasKey(e => new { e.Tipo, e.Comprobante, e.Linea, e.Ajuste })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });

                entity.ToTable("vta_ajuste_item");

                entity.HasIndex(e => e.Ajuste, "ajuste");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(4)
                    .HasColumnName("tipo")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Comprobante)
                    .HasMaxLength(16)
                    .HasColumnName("comprobante")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Linea)
                    .HasColumnType("int(11)")
                    .HasColumnName("linea");

                entity.Property(e => e.Ajuste)
                    .HasMaxLength(5)
                    .HasColumnName("ajuste")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Cantidad)
                    .HasPrecision(11, 4)
                    .HasColumnName("cantidad");

                entity.Property(e => e.Importe)
                    .HasPrecision(11, 2)
                    .HasColumnName("importe");

                entity.Property(e => e.Porcentaje)
                    .HasPrecision(5, 2)
                    .HasColumnName("porcentaje");

                entity.HasOne(d => d.AjusteNavigation)
                    .WithMany(p => p.VtaAjusteItems)
                    .HasForeignKey(d => d.Ajuste)
                    .HasConstraintName("vta_ajuste_item_ibfk_2");
            });

            modelBuilder.Entity<VtaCliente>(entity =>
            {
                entity.ToTable("vta_cliente");

                entity.HasIndex(e => e.CondicionIva, "condicion_iva");

                entity.HasIndex(e => e.CondicionVenta, "condicion_venta");

                entity.HasIndex(e => e.CondicionVentaN, "condicion_venta_n");

                entity.HasIndex(e => e.Destino, "destino");

                entity.HasIndex(e => e.Lista, "lista");

                entity.HasIndex(e => e.ModeloAsiento, "modelo_asiento");

                entity.HasIndex(e => e.ModeloAsientoCobro, "modelo_asiento_cobro");

                entity.HasIndex(e => e.Moneda, "moneda");

                entity.HasIndex(e => e.Provincia, "provincia");

                entity.HasIndex(e => e.Rubro, "rubro");

                entity.HasIndex(e => new { e.Tipo, e.Letra, e.Modelo }, "tipo");

                entity.HasIndex(e => new { e.TipoN, e.LetraN, e.ModeloN }, "tipo_n");

                entity.HasIndex(e => e.Trabajador, "trabajador");

                entity.HasIndex(e => e.Transporte, "transporte");

                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .HasColumnName("id");

                entity.Property(e => e.Actividad)
                    .HasMaxLength(100)
                    .HasColumnName("actividad");

                entity.Property(e => e.Ajuste)
                    .HasPrecision(5, 2)
                    .HasColumnName("ajuste");

                entity.Property(e => e.AjusteLista)
                    .HasPrecision(5, 2)
                    .HasColumnName("ajuste_lista");

                entity.Property(e => e.AjusteListaN)
                    .HasPrecision(5, 2)
                    .HasColumnName("ajuste_lista_n");

                entity.Property(e => e.AjusteN)
                    .HasPrecision(5, 2)
                    .HasColumnName("ajuste_n");

                entity.Property(e => e.AjusteTipo)
                    .HasColumnType("enum('PORCENTUAL','AUMENTO','GANANCIA','CONIVA','SINIVA')")
                    .HasColumnName("ajuste_tipo");

                entity.Property(e => e.AjusteTipoN)
                    .HasColumnType("enum('PORCENTUAL','AUMENTO','GANANCIA','CONIVA','SINIVA')")
                    .HasColumnName("ajuste_tipo_n");

                entity.Property(e => e.Color)
                    .HasColumnType("bit(1)")
                    .HasColumnName("color")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.ComisionCobro)
                    .HasPrecision(4, 2)
                    .HasColumnName("comision_cobro");

                entity.Property(e => e.ComisionCobro1)
                    .HasPrecision(8, 2)
                    .HasColumnName("comision_cobro$");

                entity.Property(e => e.ComisionVenta)
                    .HasPrecision(4, 2)
                    .HasColumnName("comision_venta");

                entity.Property(e => e.ComisionVenta1)
                    .HasPrecision(8, 2)
                    .HasColumnName("comision_venta$");

                entity.Property(e => e.ComprobanteAdj)
                    .HasColumnType("enum('MANUAL','AUTOMATICO')")
                    .HasColumnName("comprobante_adj");

                entity.Property(e => e.ComprobanteImp)
                    .HasColumnType("enum('MANUAL','AUTOMATICO')")
                    .HasColumnName("comprobante_imp");

                entity.Property(e => e.CondicionIva)
                    .HasMaxLength(5)
                    .HasColumnName("condicion_iva");

                entity.Property(e => e.CondicionVenta)
                    .HasMaxLength(20)
                    .HasColumnName("condicion_venta");

                entity.Property(e => e.CondicionVentaN)
                    .HasMaxLength(20)
                    .HasColumnName("condicion_venta_n");

                entity.Property(e => e.Contacto)
                    .HasMaxLength(100)
                    .HasColumnName("contacto");

                entity.Property(e => e.Cpa)
                    .HasMaxLength(10)
                    .HasColumnName("cpa");

                entity.Property(e => e.CtacteFecha).HasColumnName("ctacte_fecha");

                entity.Property(e => e.CtacteFechaN).HasColumnName("ctacte_fecha_n");

                entity.Property(e => e.CtacteLimite)
                    .HasPrecision(11, 2)
                    .HasColumnName("ctacte_limite");

                entity.Property(e => e.CtacteLimiteN)
                    .HasPrecision(11, 2)
                    .HasColumnName("ctacte_limite_n");

                entity.Property(e => e.CtacteSaldo)
                    .HasPrecision(11, 2)
                    .HasColumnName("ctacte_saldo");

                entity.Property(e => e.CtacteSaldoN)
                    .HasPrecision(11, 2)
                    .HasColumnName("ctacte_saldo_n");

                entity.Property(e => e.Destino)
                    .HasMaxLength(20)
                    .HasColumnName("destino");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .HasColumnName("direccion");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.FechaAlta).HasColumnName("fecha_alta");

                entity.Property(e => e.FechaBaja).HasColumnName("fecha_baja");

                entity.Property(e => e.FexIdimpositivo)
                    .HasMaxLength(50)
                    .HasColumnName("fex_idimpositivo");

                entity.Property(e => e.Grupo)
                    .HasMaxLength(20)
                    .HasColumnName("grupo");

                entity.Property(e => e.Latitud)
                    .HasPrecision(17, 14)
                    .HasColumnName("latitud");

                entity.Property(e => e.Letra)
                    .HasMaxLength(1)
                    .HasColumnName("letra")
                    .IsFixedLength();

                entity.Property(e => e.LetraN)
                    .HasMaxLength(1)
                    .HasColumnName("letra_n")
                    .IsFixedLength();

                entity.Property(e => e.Lista)
                    .HasMaxLength(20)
                    .HasColumnName("lista");

                entity.Property(e => e.Localidad)
                    .HasMaxLength(40)
                    .HasColumnName("localidad");

                entity.Property(e => e.Longitud)
                    .HasPrecision(17, 14)
                    .HasColumnName("longitud");

                entity.Property(e => e.Modelo)
                    .HasMaxLength(20)
                    .HasColumnName("modelo");

                entity.Property(e => e.ModeloAsiento)
                    .HasMaxLength(20)
                    .HasColumnName("modelo_asiento");

                entity.Property(e => e.ModeloAsientoCobro)
                    .HasMaxLength(20)
                    .HasColumnName("modelo_asiento_cobro");

                entity.Property(e => e.ModeloN)
                    .HasMaxLength(20)
                    .HasColumnName("modelo_n");

                entity.Property(e => e.Moneda)
                    .HasMaxLength(5)
                    .HasColumnName("moneda");

                entity.Property(e => e.NombreFantasia)
                    .HasMaxLength(100)
                    .HasColumnName("nombre_fantasia");

                entity.Property(e => e.Nota)
                    .HasPrecision(5, 2)
                    .HasColumnName("nota");

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(15)
                    .HasColumnName("numero_documento");

                entity.Property(e => e.NumeroIb)
                    .HasMaxLength(15)
                    .HasColumnName("numero_ib");

                entity.Property(e => e.ObsFactura)
                    .HasColumnType("text")
                    .HasColumnName("obs_factura");

                entity.Property(e => e.Observaciones)
                    .HasColumnType("text")
                    .HasColumnName("observaciones");

                entity.Property(e => e.Orden)
                    .HasColumnType("int(11)")
                    .HasColumnName("orden");

                entity.Property(e => e.PagoElectronico)
                    .HasMaxLength(20)
                    .HasColumnName("pago_electronico");

                entity.Property(e => e.Pais)
                    .HasMaxLength(20)
                    .HasColumnName("pais");

                entity.Property(e => e.Provincia)
                    .HasMaxLength(20)
                    .HasColumnName("provincia");

                entity.Property(e => e.Punto)
                    .HasColumnType("smallint(5)")
                    .HasColumnName("punto");

                entity.Property(e => e.PuntoN)
                    .HasColumnType("smallint(5)")
                    .HasColumnName("punto_n");

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(100)
                    .HasColumnName("razon_social");

                entity.Property(e => e.Rubro)
                    .HasMaxLength(20)
                    .HasColumnName("rubro");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(100)
                    .HasColumnName("telefono");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(4)
                    .HasColumnName("tipo");

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(5)
                    .HasColumnName("tipo_documento");

                entity.Property(e => e.TipoN)
                    .HasMaxLength(4)
                    .HasColumnName("tipo_n");

                entity.Property(e => e.Trabajador)
                    .HasMaxLength(20)
                    .HasColumnName("trabajador");

                entity.Property(e => e.Transporte)
                    .HasMaxLength(20)
                    .HasColumnName("transporte");

                entity.Property(e => e.Webpage)
                    .HasMaxLength(50)
                    .HasColumnName("webpage");

                entity.HasOne(d => d.ListaNavigation)
                    .WithMany(p => p.VtaClientes)
                    .HasForeignKey(d => d.Lista)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("vta_cliente_ibfk_6");
            });

            modelBuilder.Entity<VtaCombo>(entity =>
            {
                entity.ToTable("vta_combo");

                entity.HasIndex(e => e.Lista, "lista");

                entity.HasIndex(e => e.Moneda, "moneda");

                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .HasColumnName("id");

                entity.Property(e => e.Ajuste)
                    .HasPrecision(5, 2)
                    .HasColumnName("ajuste");

                entity.Property(e => e.AjusteLista)
                    .HasPrecision(5, 2)
                    .HasColumnName("ajuste_lista");

                entity.Property(e => e.AjusteTipo)
                    .HasColumnType("enum('PORCENTUAL','AUMENTO','GANANCIA','CONIVA','SINIVA')")
                    .HasColumnName("ajuste_tipo");

                entity.Property(e => e.Cotizacion)
                    .HasPrecision(9, 3)
                    .HasColumnName("cotizacion")
                    .HasDefaultValueSql("'1.000'");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Exento)
                    .HasPrecision(11, 2)
                    .HasColumnName("exento");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.Foto)
                    .HasColumnType("blob")
                    .HasColumnName("foto");

                entity.Property(e => e.Grupo)
                    .HasMaxLength(50)
                    .HasColumnName("grupo");

                entity.Property(e => e.Iva)
                    .HasPrecision(11, 2)
                    .HasColumnName("iva");

                entity.Property(e => e.Lista)
                    .HasMaxLength(20)
                    .HasColumnName("lista");

                entity.Property(e => e.Moneda)
                    .HasMaxLength(5)
                    .HasColumnName("moneda");

                entity.Property(e => e.Neto)
                    .HasPrecision(11, 2)
                    .HasColumnName("neto");

                entity.Property(e => e.Nogravado)
                    .HasPrecision(11, 2)
                    .HasColumnName("nogravado");

                entity.Property(e => e.Observaciones)
                    .HasColumnType("text")
                    .HasColumnName("observaciones");

                entity.Property(e => e.Orden)
                    .HasColumnType("int(11)")
                    .HasColumnName("orden");

                entity.Property(e => e.Total)
                    .HasPrecision(13, 2)
                    .HasColumnName("total");

                entity.HasOne(d => d.ListaNavigation)
                    .WithMany(p => p.VtaCombos)
                    .HasForeignKey(d => d.Lista)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("vta_combo_ibfk_2");
            });

            modelBuilder.Entity<VtaComboItem>(entity =>
            {
                entity.HasKey(e => new { e.Combo, e.Linea })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("vta_combo_item");

                entity.HasIndex(e => e.Item, "item");

                entity.HasIndex(e => e.Moneda, "moneda");

                entity.Property(e => e.Combo)
                    .HasMaxLength(20)
                    .HasColumnName("combo")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Linea)
                    .HasColumnType("int(11)")
                    .HasColumnName("linea");

                entity.Property(e => e.Ajuste)
                    .HasPrecision(5, 2)
                    .HasColumnName("ajuste");

                entity.Property(e => e.AjusteIva)
                    .HasPrecision(11, 2)
                    .HasColumnName("ajuste_iva");

                entity.Property(e => e.AjusteNeto)
                    .HasPrecision(11, 2)
                    .HasColumnName("ajuste_neto");

                entity.Property(e => e.Alicuota)
                    .HasPrecision(5, 2)
                    .HasColumnName("alicuota");

                entity.Property(e => e.Cantidad)
                    .HasPrecision(11, 4)
                    .HasColumnName("cantidad")
                    .HasDefaultValueSql("'0.0000'");

                entity.Property(e => e.Cotizacion)
                    .HasPrecision(9, 3)
                    .HasColumnName("cotizacion");

                entity.Property(e => e.Decimales)
                    .HasColumnType("int(1)")
                    .HasColumnName("decimales");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(1024)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Importe)
                    .HasPrecision(11, 2)
                    .HasColumnName("importe")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Item)
                    .HasMaxLength(20)
                    .HasColumnName("item");

                entity.Property(e => e.Iva)
                    .HasPrecision(11, 2)
                    .HasColumnName("iva");

                entity.Property(e => e.Ivainc).HasColumnName("ivainc");

                entity.Property(e => e.Moneda)
                    .HasMaxLength(5)
                    .HasColumnName("moneda");

                entity.Property(e => e.Precio)
                    .HasPrecision(12, 4)
                    .HasColumnName("precio")
                    .HasDefaultValueSql("'0.0000'");

                entity.HasOne(d => d.ComboNavigation)
                    .WithMany(p => p.VtaComboItems)
                    .HasForeignKey(d => d.Combo)
                    .HasConstraintName("vta_combo_item_ibfk_1");

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.VtaComboItems)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("vta_combo_item_ibfk_2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
