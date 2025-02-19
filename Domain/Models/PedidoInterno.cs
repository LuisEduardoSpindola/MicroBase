﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

[Table("PedidoInterno")]
public partial class PedidoInterno
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    
    public string CodigoSolicitacao { get; set; }

    [Column("CodigoEAN")]
    [StringLength(100)]
    
    public string CodigoEan { get; set; }

    [StringLength(100)]
    
    public string NomeProduto { get; set; }

    [StringLength(100)]
    
    public string Fabricante { get; set; }

    public int? Quantidade { get; set; }

    [StringLength(100)]
    
    public string DepartamentoSolicitante { get; set; }

    [StringLength(100)]
    
    public string UsuarioSolicitante { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataCadastro { get; set; }

    [StringLength(50)]
    
    public string TipoPedido { get; set; }

    [StringLength(100)]
    
    public string ServicoSolicitado { get; set; }

    [StringLength(100)]
    
    public string Fornecedor { get; set; }

    [Column(TypeName = "text")]
    public string Observacao { get; set; }
}