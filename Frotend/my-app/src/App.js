import './App.css';
import { AppRoutes } from './Routes';
import Header from './Header/Header';

const App = () => {
  return (
    <div>
      <Header />
      <AppRoutes />
    </div>
  );
};

export default App;