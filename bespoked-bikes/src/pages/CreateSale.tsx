import { useEffect, useState } from "react";
import axios from "axios";
import { Container, Form, Button, Alert } from "react-bootstrap";

const CreateSale = () => {
    type Product = {
        id: number;
        name: string;
        salePrice: number;
        commissionPercentage: number;
    };
    const [products, setProducts] = useState<Product[]>([]);
    const [salespersons, setSalespersons] = useState([]);
    const [customers, setCustomers] = useState([]);
    const [selectedProduct, setSelectedProduct] = useState<number | "">("");
    const [selectedSalesperson, setSelectedSalesperson] = useState("");
    const [selectedCustomer, setSelectedCustomer] = useState("");
    const [salePrice, setSalePrice] = useState(0);
    const [commission, setCommission] = useState(0);
    const [success, setSuccess] = useState("");
    const [error, setError] = useState("");

    useEffect(() => {
        fetchData("products", setProducts);
        fetchData("salespersons", setSalespersons);
        fetchData("customers", setCustomers);
    }, []);

    const fetchData = async (endpoint: string, setData: Function) => {
        const token = localStorage.getItem("token");
        const res = await axios.get(`https://localhost:7153/api/${endpoint}`, {
            headers: { Authorization: `Bearer ${token}` },
        });
        setData(res.data);
    };

    const handleProductChange = (e: any) => {
        const productId = Number(e.target.value);
        setSelectedProduct(productId);
        const product = products.find((p) => p.id === productId);
        if (product) {
            setSalePrice(product.salePrice);
            setCommission((product.salePrice * product.commissionPercentage) / 100);
        }
    };
;

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        try {
            const token = localStorage.getItem("token");
            await axios.post(
                "https://localhost:7153/api/sales",
                {
                    productId: selectedProduct,
                    salespersonId: selectedSalesperson,
                    customerId: selectedCustomer,
                    salesDate: new Date().toISOString(),
                    salePrice: salePrice,
                    salespersonCommission: commission,
                },
                { headers: { Authorization: `Bearer ${token}` } }
            );

            setSuccess("Sale created successfully!");
            setError("");
        } catch {
            setError("Error creating sale.");
            setSuccess("");
        }
    };

    return (
        <Container className="mt-4">
            <h2 className="mb-3">Create a Sale</h2>
            {success && <Alert variant="success">{success}</Alert>}
            {error && <Alert variant="danger">{error}</Alert>}

            <Form onSubmit={handleSubmit}>
                <Form.Group className="mb-3">
                    <Form.Label>Product</Form.Label>
                    <Form.Select onChange={handleProductChange} required>
                        <option value="">Select a product</option>
                        {products.map((p: any) => (
                            <option key={p.id} value={p.id}>
                                {p.name} (${p.salePrice})
                            </option>
                        ))}
                    </Form.Select>
                </Form.Group>

                <Form.Group className="mb-3">
                    <Form.Label>Salesperson</Form.Label>
                    <Form.Select onChange={(e) => setSelectedSalesperson(e.target.value)} required>
                        <option value="">Select a salesperson</option>
                        {salespersons.map((s: any) => (
                            <option key={s.id} value={s.id}>
                                {s.firstName} {s.lastName}
                            </option>
                        ))}
                    </Form.Select>
                </Form.Group>

                <Form.Group className="mb-3">
                    <Form.Label>Customer</Form.Label>
                    <Form.Select onChange={(e) => setSelectedCustomer(e.target.value)} required>
                        <option value="">Select a customer</option>
                        {customers.map((c: any) => (
                            <option key={c.id} value={c.id}>
                                {c.firstName} {c.lastName}
                            </option>
                        ))}
                    </Form.Select>
                </Form.Group>

                <Form.Group className="mb-3">
                    <Form.Label>Sale Price</Form.Label>
                    <Form.Control type="number" value={salePrice} disabled />
                </Form.Group>

                <Form.Group className="mb-3">
                    <Form.Label>Salesperson Commission</Form.Label>
                    <Form.Control type="number" value={commission} disabled />
                </Form.Group>

                <Button variant="primary" type="submit">
                    Create Sale
                </Button>
            </Form>
        </Container>
    );
};

export default CreateSale;
