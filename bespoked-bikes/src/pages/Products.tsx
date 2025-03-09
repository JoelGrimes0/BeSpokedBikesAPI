import { useEffect, useState } from "react";
import axios from "axios";
import { Table, Container } from "react-bootstrap";

interface Product {
    id: number;
    name: string;
    manufacturer: string;
    salePrice: number;
    qtyOnHand: number;
}

const Products = () => {
    const [products, setProducts] = useState<Product[]>([]);

    useEffect(() => {
        const fetchProducts = async () => {
            const token = localStorage.getItem("token");
            const res = await axios.get("https://localhost:5001/api/products", {
                headers: { Authorization: `Bearer ${token}` },
            });
            setProducts(res.data);
        };
        fetchProducts();
    }, []);

    return (
        <Container className="mt-4">
            <h2 className="mb-3">Products</h2>
            <Table striped bordered hover>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Manufacturer</th>
                        <th>Price</th>
                        <th>Stock</th>
                    </tr>
                </thead>
                <tbody>
                    {products.map((p: Product) => (
                        <tr key={p.id}>
                            <td>{p.name}</td>
                            <td>{p.manufacturer}</td>
                            <td>${p.salePrice}</td>
                            <td>{p.qtyOnHand}</td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </Container>
    );
};

export default Products;
