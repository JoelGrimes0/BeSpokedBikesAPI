import { useEffect, useState } from "react";
import axios from "axios";
import { Table, Container } from "react-bootstrap";

interface QuarterlyReportData {
    salespersonId: number;
    salespersonName: string;
    totalSales: number;
    totalCommission: number;
}

const QuarterlyReport = () => {
    const [report, setReport] = useState<QuarterlyReportData[]>([]);

    useEffect(() => {
        const fetchReport = async () => {
            const token = localStorage.getItem("token");
            const res = await axios.get("http://localhost:7153/api/sales/commissionReport", {
                headers: { Authorization: `Bearer ${token}` },
            });
            setReport(res.data);
        };
        fetchReport();
    }, []);

    return (
        <Container className="mt-4">
            <h2 className="mb-3">Quarterly Salesperson Commission Report</h2>
            <Table striped bordered hover>
                <thead>
                    <tr>
                        <th>Salesperson</th>
                        <th>Total Sales</th>
                        <th>Total Commission</th>
                    </tr>
                </thead>
                <tbody>
                    {report.map((r: QuarterlyReportData) => (
                        <tr key={r.salespersonId}>
                            <td>{r.salespersonName}</td>
                            <td>${r.totalSales.toFixed(2)}</td>
                            <td>${r.totalCommission.toFixed(2)}</td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </Container>
    );
};

export default QuarterlyReport;

