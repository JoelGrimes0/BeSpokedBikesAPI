import { useEffect, useState } from "react";
import axios from "axios";
import { Table, Container, Form } from "react-bootstrap";

interface Sale {
    id: number;
    product: { name: string };
    customer: { firstName: string; lastName: string };
    salesperson: { firstName: string; lastName: string };
    salesDate: string;
    salePrice: number;
    salespersonCommission: number;
}

const Sales = () => {
    const [sales, setSales] = useState<Sale[]>([]);
    const [startDate, setStartDate] = useState("");
    const [endDate, setEndDate] = useState("");

    useEffect(() => {
        fetchSales();
    }, [startDate, endDate]);

    const fetchSales = async () => {
        const token = localStorage.getItem("token");
        const res = await axios.get(`https://localhost:5001/api/sales?startDate=${startDate}&endDate=${endDate}`, {
            headers: { Authorization: `Bearer ${token}` },
        });
        setSales(res.data);
    };

    return (
        <Container className="mt-4">
            <h2 className="mb-3">Sales</h2>
            <Form className="mb-3">
                <Form.Control type="date" onChange={(e) => setStartDate(e.target.value)} />
                <Form.Control type="date" onChange={(e) => setEndDate(e.target.value)} />
            </Form>
            <Table striped bordered hover>
                <thead>
                    <tr>
                        <th>Product</th>
                        <th>Customer</th>
                        <th>Salesperson</th>
                        <th>Date</th>
                        <th>Price</th>
                        <th>Commission</th>
                    </tr>
                </thead>
                <tbody>
                    {sales.map((s: Sale) => (
                        <tr key={s.id}>
                            <td>{s.product.name}</td>
                            <td>{s.customer.firstName} {s.customer.lastName}</td>
                            <td>{s.salesperson.firstName} {s.salesperson.lastName}</td>
                            <td>{new Date(s.salesDate).toLocaleDateString()}</td>
                            <td>${s.salePrice}</td>
                            <td>${s.salespersonCommission}</td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </Container>
    );
};

export default Sales;
