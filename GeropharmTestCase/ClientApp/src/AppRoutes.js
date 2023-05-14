import { Home } from "./components/Home/Home.js";
import Items from './components/Items';

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
    {
        path: 'items',
        element: <Items />
    }
];

export default AppRoutes;
