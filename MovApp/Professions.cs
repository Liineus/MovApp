//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MovApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Professions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Professions()
        {
            this.MovieCreatorProfessions = new HashSet<MovieCreatorProfessions>();
        }
    
        public int ProfessionId { get; set; }
        public string Name { get; set; }
        public int ProfessionTypeId { get; set; }
        public Nullable<int> MoviesViewModel_MovieId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovieCreatorProfessions> MovieCreatorProfessions { get; set; }
        public virtual MoviesViewModels MoviesViewModels { get; set; }
        public virtual ProfessionTypes ProfessionTypes { get; set; }
    }
}
