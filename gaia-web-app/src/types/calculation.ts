export interface Operation {
    id: number;
    name?: string;
    type?: string;
    formula?: string;
}
export interface OperationHistory {
    id: number;
    firstField?: string;
    secondField?: string;
    operatorName?: string;
    result?: string;
}
export interface CalculationResponse {
    result?: string | null;
    history?: OperationHistory[];
    count?: number;
}
export interface CaluculationRequest {
    operationId: number;
    firstField: string;
    secondField: string;
}