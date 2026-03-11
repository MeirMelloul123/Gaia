import { useEffect, useState } from "react";
import type { CaluculationRequest, Operation } from "../types/calculation";
import { calculationService } from "../services/calculationService";

const CalculatorForm = ({ setData }: { setData: (data: any) => void }) => {
    const [operations, setOperations] = useState<Operation[]>([]);
    const [isLoading, setIsLoading] = useState(false); // État pour le bouton

    useEffect(() => {
        calculationService.getOperations()
            .then(setOperations)
            .catch(err => console.error(err));
    }, []);

    const handleCompute = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        setIsLoading(true);

        const formData = new FormData(e.currentTarget);

        const payload: CaluculationRequest = {
            firstField: formData.get("firstField") as string,
            secondField: formData.get("secondField") as string,
            operationId: Number(formData.get("operationId")),
        };

        try {
            const result = await calculationService.compute(payload);
            setData(result);
        } catch (error) {
            alert("Error occur in calculation retry again later.");
        } finally {
            setIsLoading(false);
        }
    };

    return (
        <div className="max-w-lg mx-auto p-8 bg-white shadow-2xl rounded-2xl border border-gray-100 mt-10">
            <h1 className="text-2xl font-bold text-gray-800 mb-6 text-center">Gaia Calculator</h1>

            <form className="space-y-5" onSubmit={handleCompute}>
                <div>
                    <label className="block text-sm font-semibold text-gray-600 mb-1">Field A</label>
                    <input
                        name="firstField"
                        type="text"
                        className="w-full p-3 bg-gray-50 border border-gray-200 rounded-lg focus:ring-2 focus:ring-blue-500 outline-none transition"
                        placeholder="Ex: 10"
                        required
                    />
                </div>

                <div>
                    <label className="block text-sm font-semibold text-gray-600 mb-1">Operation</label>
                    <select
                        name="operationId"
                        className="w-full p-3 bg-gray-50 border border-gray-200 rounded-lg focus:ring-2 focus:ring-blue-500 outline-none"
                        required
                        defaultValue=""
                    >
                        <option value="" disabled>Choose operation...</option>
                        {operations.map(op => (
                            <option key={op.id} value={op.id}>{op.name}</option>
                        ))}
                    </select>
                </div>

                <div>
                    <label className="block text-sm font-semibold text-gray-600 mb-1">Field B</label>
                    <input
                        name="secondField"
                        type="text"
                        className="w-full p-3 bg-gray-50 border border-gray-200 rounded-lg focus:ring-2 focus:ring-blue-500 outline-none"
                        placeholder="Ex: 5"
                        required
                    />
                </div>

                <button
                    type="submit"
                    disabled={isLoading}
                    className="w-full bg-blue-600 hover:bg-blue-700 text-white font-bold py-3 rounded-lg shadow-lg transform active:scale-95 transition disabled:opacity-50 disabled:cursor-not-allowed"
                >
                    {isLoading ? "CALCULATING..." : "CALCULATE"}
                </button>
            </form>
        </div>
    );
};

export default CalculatorForm;