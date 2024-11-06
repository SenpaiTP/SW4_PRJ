import React from 'react';
import { Container, Typography, Box } from '@mui/material'; 
import BasicButtonGroup from './Menu/MenuButton'; 
import ResponsiveDrawer from './Menu/SideBar';  // Sørg for, at stien til ResponsiveDrawer er korrekt

function Homepage() {
  return (
    <div style={{ display: 'flex' }}> {/* Brug flexbox for at sikre, at drawer kan vises korrekt */}
      <ResponsiveDrawer />
      <Container sx={{ flexGrow: 1, p: 3 }}> {/* Giv plads til main indholdet */}
        <Typography variant="h4" component="h2" gutterBottom sx={{marginTop:6, whiteSpace:'nowrap'}}>
          Welcome to the Homepage
        </Typography>
        <Box display="flex" justifyContent="center" mt={2}>
          <BasicButtonGroup /> 
        </Box>
      </Container>
    </div>
  );
}

export default Homepage; 
