using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataSharing.Models
{
   public class Product
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public double UnitPrice { get; set; }
        public String Image { get; set; }
        public String Description { get; set; }
        public int Quantity { get; set; }
        public Product()
        {
            Quantity = 1;
        }
    }

    public class DB
    {
        private static List<Product> _list = new List<Product>
        {
            new Product{Id=1001, Name="Tarte au sucre", UnitPrice=24, Image="1001.jpg", Description="Ông khẳng định: Chúng ta cần phải làm cho Trung Quốc hiểu rằng hành vi của họ đã vi phạm nghiêm trọng luật pháp quốc tế. Nó cũng xâm phạm mọi nguyên tắc về ứng xử trên biển giữa Trung Quốc và ASEAN. Cả thế giới sẽ lên án hành động này. Chương trình lấn biển đơn phương, chưa từng có tiền lệ của Trung Quốc không chỉ thách thức chủ quyền của Việt Nam và các nước láng giềng mà còn ảnh hưởng đến các lợi ích quốc gia của Mỹ. Nước Mỹ sẽ không lùi bước trước thách thức này"},
            new Product{Id=1002, Name="Vegie-spread", UnitPrice=100, Image="1002.jpg", Description="Ông khẳng định: Chúng ta cần phải làm cho Trung Quốc hiểu rằng hành vi của họ đã vi phạm nghiêm trọng luật pháp quốc tế. Nó cũng xâm phạm mọi nguyên tắc về ứng xử trên biển giữa Trung Quốc và ASEAN. Cả thế giới sẽ lên án hành động này. Chương trình lấn biển đơn phương, chưa từng có tiền lệ của Trung Quốc không chỉ thách thức chủ quyền của Việt Nam và các nước láng giềng mà còn ảnh hưởng đến các lợi ích quốc gia của Mỹ. Nước Mỹ sẽ không lùi bước trước thách thức này"},
            new Product{Id=1003, Name="Wimmers gute Semmelknadel", UnitPrice=89, Image="1003.jpg", Description="Ông khẳng định: Chúng ta cần phải làm cho Trung Quốc hiểu rằng hành vi của họ đã vi phạm nghiêm trọng luật pháp quốc tế. Nó cũng xâm phạm mọi nguyên tắc về ứng xử trên biển giữa Trung Quốc và ASEAN. Cả thế giới sẽ lên án hành động này. Chương trình lấn biển đơn phương, chưa từng có tiền lệ của Trung Quốc không chỉ thách thức chủ quyền của Việt Nam và các nước láng giềng mà còn ảnh hưởng đến các lợi ích quốc gia của Mỹ. Nước Mỹ sẽ không lùi bước trước thách thức này"},
            new Product{Id=1004, Name="Louisiana Fiery Hot Pepper Sauce", UnitPrice=100, Image="1004.jpg", Description="Ông khẳng định: Chúng ta cần phải làm cho Trung Quốc hiểu rằng hành vi của họ đã vi phạm nghiêm trọng luật pháp quốc tế. Nó cũng xâm phạm mọi nguyên tắc về ứng xử trên biển giữa Trung Quốc và ASEAN. Cả thế giới sẽ lên án hành động này. Chương trình lấn biển đơn phương, chưa từng có tiền lệ của Trung Quốc không chỉ thách thức chủ quyền của Việt Nam và các nước láng giềng mà còn ảnh hưởng đến các lợi ích quốc gia của Mỹ. Nước Mỹ sẽ không lùi bước trước thách thức này"},
            new Product{Id=1005, Name="Louisiana Hot Spiced Okra", UnitPrice=23, Image="1005.jpg", Description="Ông khẳng định: Chúng ta cần phải làm cho Trung Quốc hiểu rằng hành vi của họ đã vi phạm nghiêm trọng luật pháp quốc tế. Nó cũng xâm phạm mọi nguyên tắc về ứng xử trên biển giữa Trung Quốc và ASEAN. Cả thế giới sẽ lên án hành động này. Chương trình lấn biển đơn phương, chưa từng có tiền lệ của Trung Quốc không chỉ thách thức chủ quyền của Việt Nam và các nước láng giềng mà còn ảnh hưởng đến các lợi ích quốc gia của Mỹ. Nước Mỹ sẽ không lùi bước trước thách thức này"},
            new Product{Id=1006, Name="Laughing Lumberjack Lager", UnitPrice=154, Image="1006.jpg", Description="Ông khẳng định: Chúng ta cần phải làm cho Trung Quốc hiểu rằng hành vi của họ đã vi phạm nghiêm trọng luật pháp quốc tế. Nó cũng xâm phạm mọi nguyên tắc về ứng xử trên biển giữa Trung Quốc và ASEAN. Cả thế giới sẽ lên án hành động này. Chương trình lấn biển đơn phương, chưa từng có tiền lệ của Trung Quốc không chỉ thách thức chủ quyền của Việt Nam và các nước láng giềng mà còn ảnh hưởng đến các lợi ích quốc gia của Mỹ. Nước Mỹ sẽ không lùi bước trước thách thức này"},
            new Product{Id=1007, Name="Scottish Longbreads", UnitPrice=76, Image="1007.jpg", Description="Ông khẳng định: Chúng ta cần phải làm cho Trung Quốc hiểu rằng hành vi của họ đã vi phạm nghiêm trọng luật pháp quốc tế. Nó cũng xâm phạm mọi nguyên tắc về ứng xử trên biển giữa Trung Quốc và ASEAN. Cả thế giới sẽ lên án hành động này. Chương trình lấn biển đơn phương, chưa từng có tiền lệ của Trung Quốc không chỉ thách thức chủ quyền của Việt Nam và các nước láng giềng mà còn ảnh hưởng đến các lợi ích quốc gia của Mỹ. Nước Mỹ sẽ không lùi bước trước thách thức này"},
            new Product{Id=1008, Name="Gudbrandsdalsost", UnitPrice=23, Image="1008.jpg", Description="Ông khẳng định: Chúng ta cần phải làm cho Trung Quốc hiểu rằng hành vi của họ đã vi phạm nghiêm trọng luật pháp quốc tế. Nó cũng xâm phạm mọi nguyên tắc về ứng xử trên biển giữa Trung Quốc và ASEAN. Cả thế giới sẽ lên án hành động này. Chương trình lấn biển đơn phương, chưa từng có tiền lệ của Trung Quốc không chỉ thách thức chủ quyền của Việt Nam và các nước láng giềng mà còn ảnh hưởng đến các lợi ích quốc gia của Mỹ. Nước Mỹ sẽ không lùi bước trước thách thức này"},
            new Product{Id=1009, Name="Outback Lager", UnitPrice=89, Image="1009.jpg", Description="Ông khẳng định: Chúng ta cần phải làm cho Trung Quốc hiểu rằng hành vi của họ đã vi phạm nghiêm trọng luật pháp quốc tế. Nó cũng xâm phạm mọi nguyên tắc về ứng xử trên biển giữa Trung Quốc và ASEAN. Cả thế giới sẽ lên án hành động này. Chương trình lấn biển đơn phương, chưa từng có tiền lệ của Trung Quốc không chỉ thách thức chủ quyền của Việt Nam và các nước láng giềng mà còn ảnh hưởng đến các lợi ích quốc gia của Mỹ. Nước Mỹ sẽ không lùi bước trước thách thức này"}
        };

        public static List<Product> Products {
            get
            {
                return _list;
            }
        }

        public static List<Student> Students
        {
            get
            {
                return new List<Student>
                {
                    new Student{Id="TeoNV", Password="123", Name="Nguyễn Văn Tèo", Mark=1},
                    new Student{Id="NghiemN", Password="iloveyou", Name="Nguyễn Nghiệm", Mark=1},
                    new Student{Id="ThaoLTH", Password="iloveyou", Name="Lê Thị Hương Thảo", Mark=1}
                };
            }
        }
    }
}