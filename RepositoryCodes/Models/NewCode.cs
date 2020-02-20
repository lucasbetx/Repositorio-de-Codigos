using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RepositoryCodes.Models
{
    public class NewCode
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Titulo do repositório:")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório.")]
        [Display(Name = "Nome do usuário da postagem:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A linguagem é obrigatória.")]
        [Display(Name = "Linguagem utilizada:")]
        public string Language { get; set; }

        [Display(Name = "Descrição do código:")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Utilization { get; set; }

        [Display(Name = "Link:")]
        public string Link { get; set; }

        [Required(ErrorMessage = "A data é obrigatória.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }
}