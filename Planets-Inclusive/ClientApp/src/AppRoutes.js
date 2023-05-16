import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import Planets from "./components/Planet/Planets";

const AppRoutes = [
  {
    index: true,
    element: <Planets />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  }
];

export default AppRoutes;
