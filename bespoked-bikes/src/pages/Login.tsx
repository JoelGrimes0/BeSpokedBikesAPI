import { useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import { Form, Button, Container, Alert } from "react-bootstrap";

const Login = () => {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [error, setError] = useState("");
    const navigate = useNavigate();

    const handleLogin = async (e: React.FormEvent) => {
        e.preventDefault();
        try {
            const res = await axios.post("http://localhost:7153/api/users/login", {
                username,
                password,
            });
            localStorage.setItem("token", res.data.token);
            navigate("/dashboard");
        } catch {
            console.error(error);
            setError("Invalid credentials." );
        }
    };

    return (
        <Container className="d-flex justify-content-center align-items-center vh-100">
            <Form onSubmit={handleLogin} className="w-50 p-4 border rounded shadow">
                <h2 className="mb-3">Login</h2>
                {error && <Alert variant="danger">{error}</Alert>}
                <Form.Group className="mb-3">
                    <Form.Control
                        type="text"
                        placeholder="Username"
                        onChange={(e) => setUsername(e.target.value)}
                    />
                </Form.Group>
                <Form.Group className="mb-3">
                    <Form.Control
                        type="password"
                        placeholder="Password"
                        onChange={(e) => setPassword(e.target.value)}
                    />
                </Form.Group>
                <Button variant="primary" type="submit" className="w-100">
                    Login
                </Button>
            </Form>
        </Container>
    );
};

export default Login;
