import React, { useState, useEffect } from "react";
import { Product, getProducts } from "../services/productApi";
import { createOrder } from "../services/orderApi";

export default function OrderForm() {
  const [products, setProducts] = useState<Product[]>([]);
  const [productId, setProductId] = useState("");
  const [quantity, setQuantity] = useState(1);
  const [message, setMessage] = useState("");

  useEffect(() => {
    getProducts().then(setProducts);
  }, []);

  async function submitOrder() {
    if (!productId) return;

    await createOrder({ productId, quantity });
    setMessage("Order created successfully!");
  }

  return (
    <div>
      <h2>Create Order</h2>

      <select value={productId} onChange={e => setProductId(e.target.value)}>
        <option value="">Select product</option>
        {products.map(p => (
          <option key={p.id} value={p.id}>
            {p.name}
          </option>
        ))}
      </select>

      <input
        type="number"
        min={1}
        value={quantity}
        onChange={e => setQuantity(parseInt(e.target.value))}
      />

      <button onClick={submitOrder}>Submit Order</button>

      {message && <p>{message}</p>}
    </div>
  );
}
