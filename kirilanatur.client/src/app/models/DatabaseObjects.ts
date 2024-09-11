export interface Product {
  id: number,
  name: string,
  description: string,
  price: number,
  discount: number,
  available: boolean,
  categoryId: number,
  images: Image[]

  /*public ProductCategory? Category { get; set; }
   public List<ProductItem> ProductItems { get; set; } = [];
   public List<ProductImage> Images { get; set; } = [];*/

}

export interface Image {
  id: number,
  imageUrl: string,
  imageDescription: string,
}
