 
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HighPerformanceDAL.DTO;
using Lib.Common;

namespace HighPerformanceDAL.DTO
{
    /// <summary>
    /// Data Transfert Object relatif à School
    /// </summary>
	public class SchoolDTO : DTOBase
    {
		#region Properties

        /// <summary>
        /// Le nom de l'école.
        /// </summary>
		public string Name { get; set; }
        /// <summary>
        /// L'addresse de l'école.
        /// </summary>
		public string Address { get; set; }
        /// <summary>
        /// Le code postal de l'école.
        /// </summary>
		public int Zip { get; set; }

		#endregion

		#region Construtor

        /// <summary>
        /// Constructeur : Celui-ci ne prend aucun paramètre.
        /// Tous les types sont initialisés à leur valeur null et sont définies dans CommonBase.
        /// </summary>
        public SchoolDTO()
        {
			Name = NullValueString;
			Address = NullValueString;
			Zip = NullValueInt;
			IsNew = true;
		}

		#endregion
	}

    /// <summary>
    /// Data Transfert Object relatif à Bus
    /// </summary>
	public class BusDTO : DTOBase
    {
		#region Properties

        /// <summary>
        /// La plaque d'immatriculation du bus.
        /// </summary>
		public string LicensePlate { get; set; }
        /// <summary>
        /// L'identifiant du chauffeur du bus.
        /// </summary>
		public int DriverId { get; set; }

		#endregion

		#region Construtor

        /// <summary>
        /// Constructeur : Celui-ci ne prend aucun paramètre.
        /// Tous les types sont initialisés à leur valeur null et sont définies dans CommonBase.
        /// </summary>
        public BusDTO()
        {
			LicensePlate = NullValueString;
			DriverId = NullValueInt;
			IsNew = true;
		}

		#endregion
	}

    /// <summary>
    /// Data Transfert Object relatif à Driver
    /// </summary>
	public class DriverDTO : DTOBase
    {
		#region Properties

        /// <summary>
        /// L'identifiant du conducteur.
        /// </summary>
		public int Id { get; set; }
        /// <summary>
        /// Le prénom du conducteur.
        /// </summary>
		public string FirstName { get; set; }
        /// <summary>
        /// Le nom de famille du chauffeur du bus.
        /// </summary>
		public string LastName { get; set; }

		#endregion

		#region Construtor

        /// <summary>
        /// Constructeur : Celui-ci ne prend aucun paramètre.
        /// Tous les types sont initialisés à leur valeur null et sont définies dans CommonBase.
        /// </summary>
        public DriverDTO()
        {
			Id = NullValueInt;
			FirstName = NullValueString;
			LastName = NullValueString;
			IsNew = true;
		}

		#endregion
	}

}










namespace HighPerformanceDAL.DTO
{
    /// <summary>
    /// Ordinal lié à SchoolDTO
    /// </summary>
    public class SchoolDTOParser : DTOParser
	{
		#region Fields

		private int _ordName;
		private int _ordAddress;
		private int _ordZip;

		#endregion

		#region Methods

        /// <summary>
        /// Peuple le DTO.
        /// </summary>
        /// <param name="reader">Le reader à partir duquel les données de chaque champ doivent être récupérées.</param>
        /// <returns>L'ancêtre de notre DTO fortement typé.</returns>
        public override DTOBase PopulateDTO(SqlDataReader reader)
        {
            // Nous assumons que le reader a des données et qu'il se trouve déjà sur la ligne
            // qui contient les données dont nous avons besoin. Nous n'avons pas besoin d'appeler read.
            // En règle générale, nous vérifions que chaque champ ne soit pas égal à null.
            // Si un champ est null alors la valeur nulle de ce champ a déjà été affectée dans le constructeur du DTO,
            // Nous n'avons donc pas besoin de la changer.

			var school = new SchoolDTO();
			
			// Name
			if (!reader.IsDBNull(_ordName)) 
				school.Name = reader.GetString(_ordName);
			// Address
			if (!reader.IsDBNull(_ordAddress)) 
				school.Address = reader.GetString(_ordAddress);
			// Zip
			if (!reader.IsDBNull(_ordZip)) 
				school.Zip = reader.GetInt32(_ordZip);
			// IsNew
            school.IsNew = false;

            return school;
        }

		/// <summary>
        /// Peuple l'ordinal.
        /// </summary>
        /// <param name="reader">Le reader à partir duquel l'ordinal de chaque champ doit être récupéré.</param>
        public override void PopulateOrdinals(SqlDataReader reader)
        {			
			_ordName = reader.GetOrdinal("Name");
			_ordAddress = reader.GetOrdinal("Address");
			_ordZip = reader.GetOrdinal("Zip");
        }

		#endregion
	}

    /// <summary>
    /// Ordinal lié à BusDTO
    /// </summary>
    public class BusDTOParser : DTOParser
	{
		#region Fields

		private int _ordLicensePlate;
		private int _ordDriverId;

		#endregion

		#region Methods

        /// <summary>
        /// Peuple le DTO.
        /// </summary>
        /// <param name="reader">Le reader à partir duquel les données de chaque champ doivent être récupérées.</param>
        /// <returns>L'ancêtre de notre DTO fortement typé.</returns>
        public override DTOBase PopulateDTO(SqlDataReader reader)
        {
            // Nous assumons que le reader a des données et qu'il se trouve déjà sur la ligne
            // qui contient les données dont nous avons besoin. Nous n'avons pas besoin d'appeler read.
            // En règle générale, nous vérifions que chaque champ ne soit pas égal à null.
            // Si un champ est null alors la valeur nulle de ce champ a déjà été affectée dans le constructeur du DTO,
            // Nous n'avons donc pas besoin de la changer.

			var bus = new BusDTO();
			
			// LicensePlate
			if (!reader.IsDBNull(_ordLicensePlate)) 
				bus.LicensePlate = reader.GetString(_ordLicensePlate);
			// DriverId
			if (!reader.IsDBNull(_ordDriverId)) 
				bus.DriverId = reader.GetInt32(_ordDriverId);
			// IsNew
            bus.IsNew = false;

            return bus;
        }

		/// <summary>
        /// Peuple l'ordinal.
        /// </summary>
        /// <param name="reader">Le reader à partir duquel l'ordinal de chaque champ doit être récupéré.</param>
        public override void PopulateOrdinals(SqlDataReader reader)
        {			
			_ordLicensePlate = reader.GetOrdinal("LicensePlate");
			_ordDriverId = reader.GetOrdinal("DriverId");
        }

		#endregion
	}

    /// <summary>
    /// Ordinal lié à DriverDTO
    /// </summary>
    public class DriverDTOParser : DTOParser
	{
		#region Fields

		private int _ordId;
		private int _ordFirstName;
		private int _ordLastName;

		#endregion

		#region Methods

        /// <summary>
        /// Peuple le DTO.
        /// </summary>
        /// <param name="reader">Le reader à partir duquel les données de chaque champ doivent être récupérées.</param>
        /// <returns>L'ancêtre de notre DTO fortement typé.</returns>
        public override DTOBase PopulateDTO(SqlDataReader reader)
        {
            // Nous assumons que le reader a des données et qu'il se trouve déjà sur la ligne
            // qui contient les données dont nous avons besoin. Nous n'avons pas besoin d'appeler read.
            // En règle générale, nous vérifions que chaque champ ne soit pas égal à null.
            // Si un champ est null alors la valeur nulle de ce champ a déjà été affectée dans le constructeur du DTO,
            // Nous n'avons donc pas besoin de la changer.

			var driver = new DriverDTO();
			
			// Id
			if (!reader.IsDBNull(_ordId)) 
				driver.Id = reader.GetInt32(_ordId);
			// FirstName
			if (!reader.IsDBNull(_ordFirstName)) 
				driver.FirstName = reader.GetString(_ordFirstName);
			// LastName
			if (!reader.IsDBNull(_ordLastName)) 
				driver.LastName = reader.GetString(_ordLastName);
			// IsNew
            driver.IsNew = false;

            return driver;
        }

		/// <summary>
        /// Peuple l'ordinal.
        /// </summary>
        /// <param name="reader">Le reader à partir duquel l'ordinal de chaque champ doit être récupéré.</param>
        public override void PopulateOrdinals(SqlDataReader reader)
        {			
			_ordId = reader.GetOrdinal("Id");
			_ordFirstName = reader.GetOrdinal("FirstName");
			_ordLastName = reader.GetOrdinal("LastName");
        }

		#endregion
	}

}












namespace HighPerformanceDAL.DTO
{
    /// <summary>
    /// Fabrique de DTOParser
    /// </summary>
    internal static class DTOParserFactory
    {
		#region Static Methods
		
        /// <summary>
        /// Obtient le parser correspondant au type de DTO.
        /// </summary>
        /// <param name="dtoType">Le type du DTO.</param>
        /// <returns>Un parser fortement typé.</returns>
        internal static DTOParser GetParser(Type dtoType)
        {
            switch (dtoType.Name)
            {		
				case "SchoolDTO":
				return new SchoolDTOParser();
				case "BusDTO":
				return new BusDTOParser();
				case "DriverDTO":
				return new DriverDTOParser();
		    }
		
			// Si nous atteignons ce point, cela signifie que nous n'avons pas trouvé
			// le type correspondant. Nous levons alors une exception. alors 
			throw new Exception("Type inconnu");
		}

		#endregion
	}
}











namespace HighPerformanceDAL.BLL
{
    /// <summary>
    /// Logique métier pour la classe School.
    /// Contient la logique de validation.
    /// </summary>
	public class School : BALBase
	{
		#region Properties
		
        /// <summary>
        /// Cette propriété existe pour tous les objets de la BAL, et elle est
        /// du type DTO correspondant. Il s'agit du mécanisme
        /// que nous utilisons pour mettre en oeuvre un héritage "a un"
        /// (NDT : aussi appelé composition) au lieu d'un héritage "est un".
        /// </summary>
        public SchoolDTO Data { get; set; }
		
		#endregion

		#region Constructors
				
        /// <summary>
        /// Initialise une nouvelle instance de School
        /// </summary>
        public School() 
		{ 
			Data = new SchoolDTO(); 
		}

		/// <summary>
        /// Initialise une nouvelle instance de School à partir d'un DTO existant.
        /// </summary>
        /// <param name="dto">Un dto.</param>
        public School(SchoolDTO dto) 
		{ 
			Data = dto;
		}

		#endregion

		#region Overrided Methods
		
        /// <summary>
        /// Valide toutes les propriétés de l'objet.
        /// </summary>
        /// <returns>
        /// Une liste contenant les erreurs de validation.
        /// Si la liste est vide, les propriétés sont valides.
        /// </returns>
        public override List<ValidationError> Validate()
        {
            // Appelle toutes les fonctions de validation
			Val_Name();
			Val_Address();
			Val_Zip();
			
            // Si la liste ValidationErrors est vide, alors
            // nous avons passé la validation avec succès.
            return ValidationErrors;
        }

		#endregion

		#region Methods

        // Méthodes de validation :
        // Il y a seulement 2 exigences sur les méthodes de validation.
        // - Elles doivent gérer l'ajout d'une erreur de validation à la
        //   liste ValidationErrors si elles trouvent une erreur.
        // - Vous devez ajouter manuellement l'appel à toutes les méthodes de
        //   validation à la fonction Validate().
        // Lorsque vous créez un objet ValidationError, souvenez-vous
        // que le premier paramètre est le nom exact du champ
        // qui a la mauvaise valeur, et le message d'erreur ne doit pas
        // contenir le nom du champ, mais plutôt le tag <FieldName>,
        // qui sera remplacé par l'interface utilisateur ou par l'application appelante.

        /// <summary>
        /// Valide la propriété Name.
        /// </summary>
        /// <returns>Un booléen indiquant si la propriété est valide.</returns>
		public bool Val_Name()
		{
			// TODO : Name - Implémenter la logique de validation.
			// Name requis
			if (Data.Name == CommonBase.NullValueString)
			{
				ValidationErrors.Add(new ValidationError("School.Name", "<FieldName> est requis"));
				return false;
			}

			return true;
		}

        /// <summary>
        /// Valide la propriété Address.
        /// </summary>
        /// <returns>Un booléen indiquant si la propriété est valide.</returns>
		public bool Val_Address()
		{
			// TODO : Address - Implémenter la logique de validation.
			// Address requis
			if (Data.Address == CommonBase.NullValueString)
			{
				ValidationErrors.Add(new ValidationError("School.Address", "<FieldName> est requis"));
				return false;
			}

			return true;
		}

        /// <summary>
        /// Valide la propriété Zip.
        /// </summary>
        /// <returns>Un booléen indiquant si la propriété est valide.</returns>
		public bool Val_Zip()
		{
			// TODO : Zip - Implémenter la logique de validation.
			// Zip requis
			if (Data.Zip == CommonBase.NullValueInt)
			{
				ValidationErrors.Add(new ValidationError("School.Zip", "<FieldName> est requis"));
				return false;
			}

			return true;
		}

		#endregion
	}

    /// <summary>
    /// Logique métier pour la classe Bus.
    /// Contient la logique de validation.
    /// </summary>
	public class Bus : BALBase
	{
		#region Properties
		
        /// <summary>
        /// Cette propriété existe pour tous les objets de la BAL, et elle est
        /// du type DTO correspondant. Il s'agit du mécanisme
        /// que nous utilisons pour mettre en oeuvre un héritage "a un"
        /// (NDT : aussi appelé composition) au lieu d'un héritage "est un".
        /// </summary>
        public BusDTO Data { get; set; }
		
		#endregion

		#region Constructors
				
        /// <summary>
        /// Initialise une nouvelle instance de Bus
        /// </summary>
        public Bus() 
		{ 
			Data = new BusDTO(); 
		}

		/// <summary>
        /// Initialise une nouvelle instance de Bus à partir d'un DTO existant.
        /// </summary>
        /// <param name="dto">Un dto.</param>
        public Bus(BusDTO dto) 
		{ 
			Data = dto;
		}

		#endregion

		#region Overrided Methods
		
        /// <summary>
        /// Valide toutes les propriétés de l'objet.
        /// </summary>
        /// <returns>
        /// Une liste contenant les erreurs de validation.
        /// Si la liste est vide, les propriétés sont valides.
        /// </returns>
        public override List<ValidationError> Validate()
        {
            // Appelle toutes les fonctions de validation
			Val_LicensePlate();
			Val_DriverId();
			
            // Si la liste ValidationErrors est vide, alors
            // nous avons passé la validation avec succès.
            return ValidationErrors;
        }

		#endregion

		#region Methods

        // Méthodes de validation :
        // Il y a seulement 2 exigences sur les méthodes de validation.
        // - Elles doivent gérer l'ajout d'une erreur de validation à la
        //   liste ValidationErrors si elles trouvent une erreur.
        // - Vous devez ajouter manuellement l'appel à toutes les méthodes de
        //   validation à la fonction Validate().
        // Lorsque vous créez un objet ValidationError, souvenez-vous
        // que le premier paramètre est le nom exact du champ
        // qui a la mauvaise valeur, et le message d'erreur ne doit pas
        // contenir le nom du champ, mais plutôt le tag <FieldName>,
        // qui sera remplacé par l'interface utilisateur ou par l'application appelante.

        /// <summary>
        /// Valide la propriété LicensePlate.
        /// </summary>
        /// <returns>Un booléen indiquant si la propriété est valide.</returns>
		public bool Val_LicensePlate()
		{
			// TODO : LicensePlate - Implémenter la logique de validation.
			// LicensePlate requis
			if (Data.LicensePlate == CommonBase.NullValueString)
			{
				ValidationErrors.Add(new ValidationError("Bus.LicensePlate", "<FieldName> est requis"));
				return false;
			}

			return true;
		}

        /// <summary>
        /// Valide la propriété DriverId.
        /// </summary>
        /// <returns>Un booléen indiquant si la propriété est valide.</returns>
		public bool Val_DriverId()
		{
			// TODO : DriverId - Implémenter la logique de validation.
			// DriverId requis
			if (Data.DriverId == CommonBase.NullValueInt)
			{
				ValidationErrors.Add(new ValidationError("Bus.DriverId", "<FieldName> est requis"));
				return false;
			}

			return true;
		}

		#endregion
	}

    /// <summary>
    /// Logique métier pour la classe Driver.
    /// Contient la logique de validation.
    /// </summary>
	public class Driver : BALBase
	{
		#region Properties
		
        /// <summary>
        /// Cette propriété existe pour tous les objets de la BAL, et elle est
        /// du type DTO correspondant. Il s'agit du mécanisme
        /// que nous utilisons pour mettre en oeuvre un héritage "a un"
        /// (NDT : aussi appelé composition) au lieu d'un héritage "est un".
        /// </summary>
        public DriverDTO Data { get; set; }
		
		#endregion

		#region Constructors
				
        /// <summary>
        /// Initialise une nouvelle instance de Driver
        /// </summary>
        public Driver() 
		{ 
			Data = new DriverDTO(); 
		}

		/// <summary>
        /// Initialise une nouvelle instance de Driver à partir d'un DTO existant.
        /// </summary>
        /// <param name="dto">Un dto.</param>
        public Driver(DriverDTO dto) 
		{ 
			Data = dto;
		}

		#endregion

		#region Overrided Methods
		
        /// <summary>
        /// Valide toutes les propriétés de l'objet.
        /// </summary>
        /// <returns>
        /// Une liste contenant les erreurs de validation.
        /// Si la liste est vide, les propriétés sont valides.
        /// </returns>
        public override List<ValidationError> Validate()
        {
            // Appelle toutes les fonctions de validation
			Val_Id();
			Val_FirstName();
			Val_LastName();
			
            // Si la liste ValidationErrors est vide, alors
            // nous avons passé la validation avec succès.
            return ValidationErrors;
        }

		#endregion

		#region Methods

        // Méthodes de validation :
        // Il y a seulement 2 exigences sur les méthodes de validation.
        // - Elles doivent gérer l'ajout d'une erreur de validation à la
        //   liste ValidationErrors si elles trouvent une erreur.
        // - Vous devez ajouter manuellement l'appel à toutes les méthodes de
        //   validation à la fonction Validate().
        // Lorsque vous créez un objet ValidationError, souvenez-vous
        // que le premier paramètre est le nom exact du champ
        // qui a la mauvaise valeur, et le message d'erreur ne doit pas
        // contenir le nom du champ, mais plutôt le tag <FieldName>,
        // qui sera remplacé par l'interface utilisateur ou par l'application appelante.

        /// <summary>
        /// Valide la propriété Id.
        /// </summary>
        /// <returns>Un booléen indiquant si la propriété est valide.</returns>
		public bool Val_Id()
		{
			// TODO : Id - Implémenter la logique de validation.
			// Id requis
			if (Data.Id == CommonBase.NullValueInt)
			{
				ValidationErrors.Add(new ValidationError("Driver.Id", "<FieldName> est requis"));
				return false;
			}

			return true;
		}

        /// <summary>
        /// Valide la propriété FirstName.
        /// </summary>
        /// <returns>Un booléen indiquant si la propriété est valide.</returns>
		public bool Val_FirstName()
		{
			// TODO : FirstName - Implémenter la logique de validation.
			// FirstName requis
			if (Data.FirstName == CommonBase.NullValueString)
			{
				ValidationErrors.Add(new ValidationError("Driver.FirstName", "<FieldName> est requis"));
				return false;
			}

			return true;
		}

        /// <summary>
        /// Valide la propriété LastName.
        /// </summary>
        /// <returns>Un booléen indiquant si la propriété est valide.</returns>
		public bool Val_LastName()
		{
			// TODO : LastName - Implémenter la logique de validation.
			// LastName requis
			if (Data.LastName == CommonBase.NullValueString)
			{
				ValidationErrors.Add(new ValidationError("Driver.LastName", "<FieldName> est requis"));
				return false;
			}

			return true;
		}

		#endregion
	}

}





















