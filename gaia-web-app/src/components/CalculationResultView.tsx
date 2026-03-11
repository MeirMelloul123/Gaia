import type { CalculationResponse } from "../types/calculation";

interface Props {
    data: CalculationResponse;
}

const CalculationResultView = ({ data }: Props) => {
    return (
        <div className="mt-8 space-y-6 animate-in fade-in duration-500">
            <div className="p-6 bg-linear-to-br from-blue-600 to-blue-700 rounded-2xl text-center shadow-xl">
                <span className="text-xs font-bold text-blue-100 uppercase tracking-widest">Current Result</span>
                <div className="text-5xl font-black text-white mt-1">{data.result}</div>
            </div>

            <div className="grid grid-cols-1 gap-4">
                <div className="p-4 bg-white border border-gray-100 rounded-xl shadow-sm flex items-center justify-between">
                    <span className="text-gray-500 text-sm font-medium">Count Operations in Mouth</span>
                    <span className="bg-blue-100 text-blue-700 px-3 py-1 rounded-full font-bold text-lg">
                        {data.count}
                    </span>
                </div>
                <div className="space-y-3">
                    <h3 className="text-sm font-bold text-gray-400 uppercase tracking-wider ml-1">
                        Three Latest Operations
                    </h3>
                    {!!data && !!data?.history ? (
                        <div className="space-y-2">
                            {data.history.map((h, i) => (
                                <div key={i} className="flex justify-between items-center p-3 bg-gray-50 border border-gray-100 rounded-lg">
                                    <div className="text-sm text-gray-600">
                                        <span className="font-medium">{h.firstField}</span>
                                        <span className="mx-2 text-gray-400 text-xs">{h.operatorName}</span>
                                        <span className="font-medium">{h.secondField}</span>
                                    </div>
                                    <div className="font-mono font-bold text-blue-600">= {h.result}</div>
                                </div>
                            ))}
                        </div>
                    ) : (
                        <p className="text-xs text-gray-400 italic ml-1">No history available.</p>
                    )}
                </div>
            </div>
        </div>
    );
};

export default CalculationResultView;