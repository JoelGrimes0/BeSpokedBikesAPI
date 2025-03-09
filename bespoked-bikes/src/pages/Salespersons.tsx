import { useEffect, useState } from "react";
import axios from "axios";
import { Table, Container } from "react-bootstrap";

interface Salesperson {
    id: number;
    firstName: string;
    lastName: string;
    phone: string;
    manager: string;
}

const Salespersons = () => {
    const [salespersons, setSalespersons] = useState([]);

    useEffect(() => {
        const fetchSalespersons = async () => {
            const token = localStorage.getItem("token");
            const res = await axios.get("http://localhost:7153/api/salespersons/allSalespersons", {
                headers: { Authorization: `Bearer ${token}` },
            });
            setSalespersons(res.data);
        };
        fetchSalespersons();
    }, []);

    return (
        <Container className="mt-4">
            <h2 className="mb-3">Salespersons</h2>
            <Table striped bordered hover>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Phone</th>
                        <th>Manager</th>
                    </tr>
                </thead>
                <tbody>
                    {salespersons.map((s: Salesperson) => (
                        <tr key={s.id}>
                            <td>{s.firstName} {s.lastName}</td>
                            <td>{s.phone}</td>
                            <td>{s.manager}</td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </Container>
    );
};

export default Salespersons;
