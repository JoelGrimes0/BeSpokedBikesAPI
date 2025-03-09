import { Link } from "react-router-dom";
import { Container, ListGroup } from "react-bootstrap";

const Dashboard = () => {
    return (
        <Container className="mt-5">
            <h2 className="mb-4">Dashboard</h2>
            <ListGroup>
                <ListGroup.Item action as={Link} to="/salespersons">Salespersons</ListGroup.Item>
                <ListGroup.Item action as={Link} to="/products">Products</ListGroup.Item>
                <ListGroup.Item action as={Link} to="/customers">Customers</ListGroup.Item>
                <ListGroup.Item action as={Link} to="/sales">Sales</ListGroup.Item>
                <ListGroup.Item action as={Link} to="/create-sale">Create Sale</ListGroup.Item>
                <ListGroup.Item action as={Link} to="/quarterly-report">Quarterly Report</ListGroup.Item>
            </ListGroup>
        </Container>
    );
};

export default Dashboard;
