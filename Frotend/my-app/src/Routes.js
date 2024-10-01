import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Frontpage from './pages/frontpage'; // Use default import
import Indkomst from './pages/indkomst'; // Use default import
import Udgifter from './pages/udgifter'; // Use default import
import Indstillinger from './pages/indstillinger'; // Use default import
import Login from './pages/login'; // Use default import
import ForgotPassword from './pages/forgotpassword'; // Forgot Password component
import Register from './pages/register'; // Register component

export const AppRoutes = () => {
  return (
    <Router>
      <Routes>
        <Route path="/frontpage" element={<Frontpage />} />
        <Route path="/indkomst" element={<Indkomst />} />
        <Route path="/udgifter" element={<Udgifter />} />
        <Route path="/indstillinger" element={<Indstillinger />} />
        <Route path="/login" element={<Login />} />
        <Route path="/forgot-password" element={<ForgotPassword />} /> {/* Forgot Password Route */}
        <Route path="/register" element={<Register />} /> {/* Register Route */}
        </Routes>
    </Router>
  );
};



