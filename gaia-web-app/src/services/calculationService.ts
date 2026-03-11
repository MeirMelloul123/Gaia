
import type { CaluculationRequest, Operation } from "../types/calculation";

const apiUrl = import.meta.env.VITE_API_BASE_URL;

export const calculationService = {
    getOperations: async (): Promise<Operation[]> => {
        const response = await fetch(`${apiUrl}`);
        if (!response.ok) throw new Error("Failed to fetch operations");
        return response.json();
    },

    compute: async (payload: CaluculationRequest) => {
        const response = await fetch(`${apiUrl}/compute`, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(payload),
        });
        if (!response.ok) throw new Error("Failed to compute result");
        return response.json();
    }
};