export interface Product {
  id: number,
  name: string,
  description: string,
  price: number,
  discount: number,
  available: boolean,
  categoryId: number,

/*
public ProductCategory? Category { get; set; }

public List<ProductItem> ProductItems { get; set; } = [];
public List<ProductImage> Images { get; set; } = [];*/

}
