using MaintainEvision.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaintainEvision.ViewModel
{
    public class CodeReasonCreateViewModel : IValidatableObject
    {
        [StringLength(10, ErrorMessage = "欄位長度不得大於 10 個字元")]
        [Required]
        public string AllowShip { get; set; }

        [StringLength(100, ErrorMessage = "欄位長度不得大於 100 個字元")]
        public string ChsDesc { get; set; }

        [StringLength(100, ErrorMessage = "欄位長度不得大於 100 個字元")]
        public string ChtDesc { get; set; }

        [StringLength(10, ErrorMessage = "欄位長度不得大於 10 個字元")]
        [Required]
        public string CodeType { get; set; }

        [StringLength(10, ErrorMessage = "欄位長度不得大於 10 個字元")]
        public string DefaultEcn { get; set; }

        [StringLength(10, ErrorMessage = "欄位長度不得大於 10 個字元")]
        public string DefaultUsed { get; set; }

        [StringLength(10, ErrorMessage = "欄位長度不得大於 10 個字元")]
        public string Duty { get; set; }

        [StringLength(100, ErrorMessage = "欄位長度不得大於 100 個字元")]
        public string EngDesc { get; set; }

        [StringLength(2, ErrorMessage = "欄位長度不得大於 2 個字元")]
        public string Outsourcing { get; set; }

        [StringLength(20, ErrorMessage = "欄位長度不得大於 20 個字元")]
        public string ProcessType { get; set; }

        [StringLength(20, ErrorMessage = "欄位長度不得大於 20 個字元")]
        [Required]
        public string ProductType { get; set; }

        [StringLength(20, ErrorMessage = "欄位長度不得大於 20 個字元")]
        [Required]
        public string ReasonCode { get; set; }

        [StringLength(10, ErrorMessage = "欄位長度不得大於 10 個字元")]
        public string RequierAttn { get; set; }

        [StringLength(10, ErrorMessage = "欄位長度不得大於 10 個字元")]
        public string RequireBios { get; set; }

        [StringLength(10, ErrorMessage = "欄位長度不得大於 10 個字元")]
        public string RequireCustSn { get; set; }

        [StringLength(10, ErrorMessage = "欄位長度不得大於 10 個字元")]
        public string RequireMfgSn { get; set; }

        [StringLength(10, ErrorMessage = "欄位長度不得大於 10 個字元")]
        public string RequireRelabel { get; set; }

        [StringLength(10, ErrorMessage = "欄位長度不得大於 10 個字元")]
        public string RequireRemark { get; set; }

        [StringLength(10, ErrorMessage = "欄位長度不得大於 10 個字元")]
        public string RequireSwapInfo { get; set; }

        [StringLength(20, ErrorMessage = "欄位長度不得大於 20 個字元")]
        [Required]
        public string Vender { get; set; }

        //驗證資料重複
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            EvisionConnectionString db = new EvisionConnectionString();
            var Reason = db.CodeReason
                .Where(p => p.Vender == Vender && p.ProductType == ProductType && p.ReasonCode == ReasonCode && p.CodeType == CodeType)
                .FirstOrDefault();

            if (Reason != null)
            {
                yield return new ValidationResult("Reason Code 已存在", new string[] { "ReasonCode" });
            }
        }
    }
}