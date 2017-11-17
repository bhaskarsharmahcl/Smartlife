
namespace Sitecore.Feature.Product
{
    using Sitecore.Data;
    using System;

    public struct Templates
    {
        public struct Products
        {
            public struct Fields
            {
            }

            public static readonly ID ID = new ID("{CB016F0A-E2DF-4FCB-9AE0-DC42829AE0CB}");
        }

        public struct ProductCategory
        {
            public struct Fields
            {
                public static readonly ID CategoryTitle = new ID("{1ABE07D2-4151-4AE2-84A4-34FBE4CB3ED4}");

                public const string CategoryTitle_FieldName = "Category Title";

                public static readonly ID CategoryShortDescription = new ID("{08F1AE01-4ECF-47DA-907B-3A616C3AE8F8}");

                public const string CategoryShortDescription_FieldName = "Category Short Description";

                public static readonly ID CategoryDescription = new ID("{93BD5251-A514-4174-9062-37AF88E3E0F6}");

                public const string CategoryDescription_FieldName = "Category Description";

                public static readonly ID CategoryImage = new ID("{134514ED-509F-4296-9833-05F826005573}");
            }

            public static readonly ID ID = new ID("{EF48B4DE-E939-4065-8639-5E5C8EDC04CF}");
        }

        public struct Product
        {
            public struct Fields
            {
                public static readonly ID ProductTitle = new ID("{C236FB11-AB2F-42A7-92A7-09A9258E2637}");

                public const string ProductTitle_FieldName = "Product Title";

                public static readonly ID ProductSubTitle = new ID("{527BCBF8-A38C-4393-8D9D-88189D0C84EB}");

                public const string ProductSubTitle_FieldName = "Product Sub Title";

                public static readonly ID ShortDescription = new ID("{DE1430C5-291B-40C2-AD2D-709EFBB7360A}");

                public const string ShortDescription_FieldName = "Short Description";

                public static readonly ID Description = new ID("{398AAABE-2E1A-4E7C-A4A6-0F7AFC544D93}");

                public const string Description_FieldName = "Description";

                public static readonly ID Features = new ID("{0D4A62EE-BF47-4FBE-B35A-55631CCED460}");

                public const string Features_FieldName = "Features";

                public static readonly ID Specification = new ID("{A7A9E7DB-2D07-4600-BA59-19B75984D982}");

                public const string Specification_FieldName = "Specification";

                public static readonly ID Price = new ID("{9D615E6C-6493-4A5A-9F15-27ADF03EA198}");

                public const string Price_FieldName = "Price";

                public static readonly ID DiscountedPrice = new ID("{40D24AA7-4AAF-48C1-86BB-B0F00C3DC525}");

                public const string DiscountedPrice_FieldName = "Discounted Price";

                public static readonly ID Shipping = new ID("{71D65CAF-388F-4A54-B386-5C0CAFC6CDE1}");

                public const string Shipping_FieldName = "Shipping";

                public static readonly ID ProductImage = new ID("{0BE11D55-96E6-408A-BE0E-83836DB67232}");

                public static readonly ID ProductLargeImage = new ID("{4B517CB2-AB6E-4512-BEC3-943778E02BB2}");

                public static readonly ID Reviews = new ID("{FDC46723-8FD1-44C0-9938-C7BC00A81768}");

                public const string Reviews_FieldName = "Reviews";

                public static readonly ID Rating = new ID("{77C15B3E-BA56-4719-843D-C0BBAE6CC215}");

                public const string Rating_FieldName = "Rating";
            }

            public static readonly ID ID = new ID("{DB5FFDDA-1D7D-4A75-96BA-11D08658E783}");
        }

        public struct HasProductSelector
        {
            public struct Fields
            {
                public static readonly ID ProductSelector = new ID("{EA8C07F8-1E24-4DF7-8005-E5B39FF6D0FC}");
            }

            public static readonly ID ID = new ID("{5EBD3711-3DE8-44A7-AA64-635F421555B7}");
        }

        public struct HasPageContent
        {
            public struct Fields
            {
                public static readonly ID Title = new ID("{C30A013F-3CC8-4961-9837-1C483277084A}");

                public const string Title_FieldName = "Title";

                public static readonly ID Summary = new ID("{AC3FD4DB-8266-476D-9635-67814D91E901}");

                public const string Summary_FieldName = "Summary";

                public static readonly ID Body = new ID("{D74F396D-5C5E-4916-BD0A-BFD58B6B1967}");

                public const string Body_FieldName = "Body";

                public static readonly ID Image = new ID("{9492E0BB-9DF9-46E7-8188-EC795C4ADE44}");
            }

            public static readonly ID ID = new ID("{AF74A00B-8CA7-4C9A-A5C1-156A68590EE2}");
        }
    }
}
