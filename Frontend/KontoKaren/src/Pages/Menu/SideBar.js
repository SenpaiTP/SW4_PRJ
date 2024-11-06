import * as React from 'react';
import PropTypes from 'prop-types';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import CssBaseline from '@mui/material/CssBaseline';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import Menu from '@mui/material/Menu';
import MenuItem from '@mui/material/MenuItem';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';

function ResponsiveHeaderMenu(props) {
  const [anchorEl, setAnchorEl] = React.useState(null);

  const handleMenuOpen = (event) => {
    setAnchorEl(event.currentTarget);
  };

  const handleMenuClose = () => {
    setAnchorEl(null);
  };

  const menuItems = ['Login'];

  return (
    <Box sx={{ display: 'flex' }}>
      <CssBaseline />
      <AppBar position="fixed">
        <Toolbar>
          {/* Menu-icon for mobile */}
          <IconButton
            color="inherit"
            aria-label="open menu"
            edge="start"
            onClick={handleMenuOpen}
            sx={{ mr: 2, display: { xs: 'block', sm: 'none' } }}
          >
            <MenuIcon />
          </IconButton>

          <AppBar position="fixed">
  <Toolbar>
    {/* Menu-icon for mobile */}
    <IconButton
      color="inherit"
      aria-label="open menu"
      edge="start"
      onClick={handleMenuOpen}
      sx={{ mr: 2, display: { xs: 'block', sm: 'none' } }}
    >
      <MenuIcon />
    </IconButton>

    {/* Centered App title */}
    <Box sx={{ flexGrow: 1, display: 'flex', justifyContent: 'center' }}>
      <Typography variant="h6" noWrap component="div">
        KontoKaren
      </Typography>
    </Box>

    {/* Desktop menu items */}
    <Box sx={{ display: { xs: 'none', sm: 'block' } }}>
      {menuItems.map((item) => (
        <Button key={item} color="inherit">
          {item}
        </Button>
      ))}
    </Box>
  </Toolbar>
</AppBar>

          {/* Desktop menu items */}
          <Box sx={{ display: { xs: 'none', sm: 'block' } }}>
            {menuItems.map((item) => (
              <Button key={item} color="inherit">
                {item}
              </Button>
            ))}
          </Box>

          {/* Mobile dropdown menu */}
          <Menu
            anchorEl={anchorEl}
            open={Boolean(anchorEl)}
            onClose={handleMenuClose}
            sx={{ display: { xs: 'block', sm: 'none' } }}
          >
            {menuItems.map((item) => (
              <MenuItem key={item} onClick={handleMenuClose}>
                {item}
              </MenuItem>
            ))}
          </Menu>
        </Toolbar>
      </AppBar>

      {/* Main content area */}
      <Box component="main" sx={{ flexGrow: 1, p: 3, mt: 8 }}>
        <Typography variant="h4" gutterBottom>
          Main Content
        </Typography>
        <Typography paragraph>
          This is the main content area where your page content will appear.
        </Typography>
      </Box>
    </Box>
  );
}

ResponsiveHeaderMenu.propTypes = {
  window: PropTypes.func,
};

export default ResponsiveHeaderMenu;
