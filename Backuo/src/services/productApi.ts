const PRODUCT_API = "http://localhost:5001/api/products"; 
// adjust port based on your ProductService

export interface Product {
  id?: string;
  name: string;
  price: number;
}

export async function getProducts(): Promise<Product[]> {
  const response = await fetch(PRODUCT_API);
  return response.json();
}
