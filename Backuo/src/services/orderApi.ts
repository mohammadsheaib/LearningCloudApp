const ORDER_API = "http://localhost:5002/api/orders"; 
// adjust port based on your OrderService

import { Product } from "./productApi";

export interface Order {
  id?: string;
  productId: string;
  quantity: number;
}

export async function createOrder(order: Order): Promise<any> {
  const response = await fetch(ORDER_API, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(order)
  });

  return response.json();
}
