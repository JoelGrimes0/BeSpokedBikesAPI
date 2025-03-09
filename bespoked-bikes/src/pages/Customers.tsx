import { useEffect, useState } from "react";
import axios from "axios";
import { Table, Container } from "react-bootstrap";

interface Customer {
    id: number;
    firstName: string;
    lastName: string;
    phone: string;
}

const Customers = () => {
    const [customers, setCustomers] = useState<Customer[]>([]);

    useEffect(() => {
        const fetchCustomers = async () => {
            const token = localStorage.getItem("token");
            const res = await axios.get("http://localhost:7153/api/customers/allcustomers", {
                headers: { Authorization: `Bearer ${token}` },
            });
            setCustomers(res.data);
        };
        fetchCustomers();
    }, []);

    return (
        <Container className="mt-4">
            <h2 className="mb-3">Customers</h2>
            <Table striped bordered hover>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Phone</th>
                    </tr>
                </thead>
                <tbody>
                    {customers.map((c: Customer) => (
                        <tr key={c.id}>
                            <td>{c.firstName} {c.lastName}</td>
                            <td>{c.phone}</td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </Container>
    );
};

export default Customers;
