import { Route, Routes } from "react-router-dom";
import Login from "./pages/Login";
import Dashboard from "./pages/Dashboard";
import Salespersons from "./pages/Salespersons";
import Products from "./pages/Products";
import Customers from "./pages/Customers";
import Sales from "./pages/Sales";
import CreateSale from "./pages/CreateSale";
import QuarterlyReport from "./pages/QuarterlyReport";

function App() {
    return (
        <Routes>
            <Route path="/" element={<Login />} />
            <Route path="/dashboard" element={<Dashboard />} />
            <Route path="/salespersons" element={<Salespersons />} />
            <Route path="/products" element={<Products />} />
            <Route path="/customers" element={<Customers />} />
            <Route path="/sales" element={<Sales />} />
            <Route path="/create-sale" element={<CreateSale />} />
            <Route path="/quarterly-report" element={<QuarterlyReport />} />
        </Routes>
    );
}

export default App;
