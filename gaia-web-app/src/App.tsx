import { useState, type JSX } from "react";
import CalculatorForm from "./components/CalculatorForm";
import CalculationResultView from "./components/CalculationResultView";


export default function App(): JSX.Element {
  const [data, setData] = useState({});

  return (
    <div className="from-blue-100  flex items-center justify-center">
      <div className="max-w w-full p-10 bg-white  rounded-3xl border border-gray-100">
        <h1 className="text-4xl font-extrabold text-gray-800 mb-8 text-center">Welcome to Gaia Web App</h1>
        <p className="text-lg text-gray-600 mb-6 text-center">Your ultimate calculator for numbers and strings!</p>
        <div className="flex flex-col md:flex-row gap-10">
          {/* Calculator Form */}
          <div className="md:w-1/2">
            <CalculatorForm setData={setData} />
          </div>
          {/* History Section */}
          <div className="md:w-1/2">
            <div className="p-6 bg-gray-50 rounded-2xl shadow-lg">
              <CalculationResultView data={data} />
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}